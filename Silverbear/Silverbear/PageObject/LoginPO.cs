using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Silverbear.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Silverbear.PageObject
{
    public class LoginPO
    {
        private IWebDriver driver;
        private IWait<OpenQA.Selenium.IWebDriver> iWait;
        string username, password;
        Config objConfig = null;

        public LoginPO(IWebDriver driver, IWait<OpenQA.Selenium.IWebDriver> iWait)
        {
            this.driver = driver;
            this.iWait = iWait;
        }

        public void login(string userRole)
        {
            if (userRole.Equals("System Admin"))
            {
                //driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");

                username = ConfigurationManager.AppSettings["ApplicationUsername"];

                password = ConfigurationManager.AppSettings["ApplicationPassword"];

                AutoItX.WinWaitActive("Windows Security");
                AutoItX.Send("dev\\" + username);
                AutoItX.Send("{TAB}");
                Thread.Sleep(2000);
                AutoItX.Send(password);
                //AutoItX.Send("{!}");
                Thread.Sleep(2000);
                AutoItX.Send("{TAB}");
                AutoItX.Send("{TAB}");
                AutoItX.Send("{ENTER}");

            }
            else if (userRole.Equals("KS"))
            {
                username = objConfig.readingXMLFile("SilverBearCRM", "Login", "KSUserName", "Config.xml");

                password = objConfig.readingXMLFile("SilverBearCRM", "Login", "KSPassWord", "Config.xml");

                AutoItX.WinWaitActive("Windows Security");
                AutoItX.Send("dev\\" + username);
                AutoItX.Send("{TAB}");
                Thread.Sleep(2000);
                AutoItX.Send(password);
                //AutoItX.Send("{!}");
                Thread.Sleep(2000);
                AutoItX.Send("{TAB}");
                AutoItX.Send("{TAB}");
                AutoItX.Send("{ENTER}");

            }
            else if (userRole.Equals("MPD"))
            {
                username = objConfig.readingXMLFile("SilverBearCRM", "Login", "MPDUserName", "Config.xml");

                password = objConfig.readingXMLFile("SilverBearCRM", "Login", "MPDPassWord", "Config.xml");

                AutoItX.WinWaitActive("Windows Security");
                AutoItX.Send("dev\\" + username);
                AutoItX.Send("{TAB}");
                Thread.Sleep(2000);
                AutoItX.Send(password);
                //AutoItX.Send("{!}");
                Thread.Sleep(2000);
                AutoItX.Send("{TAB}");
                AutoItX.Send("{TAB}");
                AutoItX.Send("{ENTER}");

            }


        }


    }
}
