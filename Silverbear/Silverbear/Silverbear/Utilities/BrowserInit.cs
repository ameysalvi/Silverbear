using AutoIt;
using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Silverbear.Browser;
using Silverbear.Common;
using Silverbear.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Silverbear.Utilities
{
    public class BrowserInit
    {
        public IWebDriver driver;
        internal string driverName = string.Empty;
        internal string driverPath = string.Empty;
        public IWait<IWebDriver> iWait = null;
        Browsers browser = new Browsers();
        Helper helper = new Helper();

        int screenHeight, screenWidth;

        public BrowserInit()
        {

            try
            {
                string rootPath = Environment.CurrentDirectory;

                if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.firefox.ToString(), "Browser.xml")) == true)
                {
                    string s = ConfigurationManager.AppSettings["ApplicationURL"];
                    driverPath = @"D:\IET_Automation\Silverbear\Silverbear\Silverbear\Library";
                    driverName = "webdriver.gecko.driver";
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverPath);
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox.\firefox.exe";
                    FirefoxOptions options = new FirefoxOptions();
                    options.AcceptInsecureCertificates = true;
                    options.SetPreference("webdriver_assume_untrusted_issuer", true);
                    driver = new FirefoxDriver(service, options);

                    Current.BrowserName = BrowserCollection.firefox.ToString();

                    screenHeight = Helper.GetScreenHeight(driver);

                    screenWidth = Helper.GetScreenWidth(driver);

                    Helper.SetWindowPosition(driver, 0, 0);

                    Helper.SetWindowSize(driver, screenWidth, screenHeight);

                }
                else if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.chrome.ToString(), "Browser.xml")) == true)
                {
                    driverPath = @"D:\IET_Automation\Silverbear\Silverbear\Silverbear\bin\Debug\Library";
                    //driverPath = AppDomain.CurrentDomain.BaseDirectory + "chromedriver";
                    driverName = "webdriver.chrome.driver";

                    ChromeOptions options = new ChromeOptions();

                    options.AddArgument("--disable-extensions");

                    options.AddArgument("--disable-extensions");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AcceptInsecureCertificates = true;

                    #region pdf verification
                    //string downloadDirectory = ConfigurationManager.AppSettings["PDFPath"];
                    // var downloadDirectory = @"D:\MUM-DSK-335-Madhura\InspecCode\InspecPlus\IET.Inspec.Ideas.AcceptanceTests\pdfUpload";

                    //options.AddUserProfilePreference("download.default_directory", downloadDirectory);

                    //options.AddUserProfilePreference("download.prompt_for_download", false);

                    //options.AddUserProfilePreference("disable-popup-blocking", "true");
                    #endregion
                    driver = new ChromeDriver(driverPath, options);                

                    Current.BrowserName = BrowserCollection.chrome.ToString();

                    screenHeight = Helper.GetScreenHeight(driver);

                    screenWidth = Helper.GetScreenWidth(driver);

                    Helper.SetWindowPosition(driver, 0, 0);

                    Helper.SetWindowSize(driver, screenWidth, screenHeight);

                    Console.WriteLine("Is Driver null :: " + (driver == null));

                }
                else if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.ie.ToString(), "Browser.xml")) == true)
                {
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.EnsureCleanSession = true;
                    options.EnableNativeEvents = true;
                    options.IgnoreZoomLevel = true;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driverName = "webdriver.ie.driver";
                    driverPath = @"D:\IET_Automation\Silverbear\Silverbear\Silverbear\Library\IEDriverServer.exe";

                    driver = new InternetExplorerDriver(options);
                    screenHeight = Helper.GetScreenHeight(driver);

                    screenWidth = Helper.GetScreenWidth(driver);

                    Helper.SetWindowPosition(driver, 0, 0);

                    Helper.SetWindowSize(driver, screenWidth, screenHeight);

                    Current.BrowserName = BrowserCollection.ie.ToString();

                    // Add code to add Registry in IE 11
                    Current.IEVersion = Helper.GetIEVersion(driver, driver.FindElement(By.TagName("html")));

                    if (Current.IEVersion.Equals("IE11"))
                        Helper.CheckIE11RegistryPresence();

                }
                else if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.headless.ToString(), "Browser.xml")) == true)
                {
                    #region Chrome headless   We are prefering chrome as our headless browser since it is robust and phantomJS driver is deprecated in 2019 VS version
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--headless");
                    driver = new ChromeDriver(option);
                    #endregion

                    #region Mozilla Firefox
                    //driverPath = @"D:\IET_Automation\Silverbear\Silverbear\Silverbear\Library\";
                    //driverName = "webdriver.gecko.driver";
                    //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverPath);
                    //service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox.\firefox.exe";
                    //var options = new FirefoxOptions();
                    //options.AddArguments("--headless");
                    //driver = new FirefoxDriver(service, options);
                    #endregion

                    Current.BrowserName = BrowserCollection.headless.ToString();

                    screenHeight = Helper.GetScreenHeight(driver);

                    screenWidth = Helper.GetScreenWidth(driver);

                    Helper.SetWindowPosition(driver, 0, 0);

                    Helper.SetWindowSize(driver, screenWidth, screenHeight);

                }
                else
                    throw new NoBrowserSelectedException();
                
                iWait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(120.00));

            }
            catch (NoBrowserSelectedException ex)
            {
                Logger.log.Error("Error In Browser Selection.");
                Logger.log.Error(ex);
            }
            catch (Exception ex)
            {
                Logger.log.Error("Error In Browser Initialization.");
                Logger.log.Error(ex);
            }
        }
        
        internal void GoToUrl(string URL)
        {
            try
            {
                driver.Navigate().GoToUrl(URL);             

                iWait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                #region Manually click on Advance in IE for unsecure certificates and then click on more information tab
                //driver.FindElement(By.CssSelector("div#certErrorAndCaptivePortalButtonContainer > button#advancedButton")).Click();
                //driver.FindElement(By.LinkText("More information")).Click();
                //IWebElement WebPageNotRecommended = driver.FindElement(By.LinkText("Go on to the webpage (not recommended)"));
                //Thread.Sleep(2000);
                //WebPageNotRecommended.Click(); 
                #endregion

                if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.ie.ToString(), "Browser.xml")) == true)
                {
                     if (driver.Url.Contains("https")) driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
                     Thread.Sleep(3000);                    
                }

            }

            catch (Exception error)
            {
                Logger.log.Error("Browser could not navigate to the specified url properly");
                Logger.log.Error(error);
            }
        }

    }

    public class NoBrowserSelectedException : Exception
    {
        public override String Message
        {
            get
            {
                return "Please select any browser by setting flag in Base.Config file as true";
            }
        }
    }
}
