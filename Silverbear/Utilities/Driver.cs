using OpenQA.Selenium;
using Silverbear.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverbear.Utilities
{
    public class Driver
    {
        Config config = new Config();

        public static BrowserInit browser { get; set; }

        public static void Intitialize()
        {
            browser = new BrowserInit();
            TurnOnWait();
        
            browser.driver.Manage().Window.Maximize();
        }

        public static void Navigate(String homeURL)
        {
            browser.GoToUrl(homeURL);
            //browser.driver.Navigate().GoToUrl(homeURL);
        }
        
        public static void Close()
        {
            if (browser.driver != null)
                browser.driver.Quit();
                browser.driver.Dispose();
        }

        private static void TurnOnWait()
        {
            browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }
    }
}
