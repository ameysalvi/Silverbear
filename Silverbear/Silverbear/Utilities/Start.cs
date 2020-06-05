using AutoIt;
using OpenQA.Selenium;
using Silverbear.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Silverbear.Utilities
{
    [Binding]
    public class Start: Driver
    {
        Config config = new Config();
        Objects obj = null;

        [BeforeScenario]
        public void Setup()
        {
            #region Initialization 

            // Initiating Logger
            Logger.SetLogger();

            // Initiating Browser
            Intitialize();

            // Initializing all the Page Objects
            obj = new Objects(Driver.browser.driver, Driver.browser);
            obj.ObjectInitialization();

            // Navigating to URL
            string s = ConfigurationManager.AppSettings["ApplicationURL"];
            Driver.Navigate(s);

            #region Using AutoIT for handling windows and desktop applications
            //String username = ConfigurationManager.AppSettings["ApplicationUsername"];

            //String password = ConfigurationManager.AppSettings["Applicationpassword"];

            //AutoItX.WinWaitActive("Windows Security");
            //AutoItX.Send("dev\\" + username);
            //AutoItX.Send("{TAB}");
            //Thread.Sleep(2000);
            //AutoItX.Send(password);
            //////AutoItX.Send("{!}");
            //Thread.Sleep(2000);
            //AutoItX.Send("{TAB}");
            //AutoItX.Send("{TAB}");
            //AutoItX.Send("{ENTER}");
            #endregion           

            #endregion

            // Writing Currently executing Scenario
            Logger.log.Info("**** Scenario " + ScenarioContext.Current.ScenarioInfo.Title + " **** started.");
            Console.WriteLine("\n\n**** Scenario " + ScenarioContext.Current.ScenarioInfo.Title + " **** started.");
        }

        [AfterScenario]
        public void TearDown()
        {
            // Closing the browser
            Close();             

            if (ScenarioContext.Current.TestError != null)
            {
                Console.WriteLine(ScenarioContext.Current.TestError.Message);
                Console.WriteLine(ScenarioContext.Current.TestError.StackTrace);

                Logger.log.Info(ScenarioContext.Current.TestError.Message);
                Logger.log.Info(ScenarioContext.Current.TestError.StackTrace);
            }
        }  
      
    }
}
