using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Silverbear.Common;
using Silverbear.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace Silverbear.PageObject
{
    public class IE_Silverbear_Contact_PO
    {
        #region Variable declaration and object initialisation

        private IWebDriver driver;
        private IWait<OpenQA.Selenium.IWebDriver> iWait;

        //string Title, DOB;
        string lastName, postName, firstName, newContactURL, middleName, jobTitle, suffix, knownAs, homeEmail, workEmail, eduEmail, emailAlias, prefEmail, mobPhone, homePhone;

        string buPhone, eduPhone, homeFax, buFax, addName, street1, street2, street3, city, county, postalcode, country, parentorg, prevName, gender, prefContact, optEmail, optBulkMail, optBulkEmail;

        string optSurvey, optSMS, optPhone, optFax, optMail, OptOut, SendMktMat, prefLeadSource, contactImportSource, eduAddName, eduAddStreet1, eduAddStreet2, eduAddStreet3, eduAddCity, eduAddCounty, eduAddPostal, eduAddCountry;

        string workAddName, workAddStreet1, workAddStreet2, workAddStreet3, workAddCity, workAddCounty, workAddPostal, workAddCountry, salutation;

        string transResult, contactRefNo1, contactRefNo2, contactRefNo, contactRefNoRec0, contactRefNoRec1, searchRec = "AUTO-USR", homeInvalidCheck, eduInvalidCheck, workInvalidCheck;

        string driverName = "", driverPath, appURL;

        string contactReferenceNumber;

        string jobLevel, jobDept;

        public string videoName;

        public string DarwinKey;

        Config objConfig = null;

        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        int recordSize;

        IWebElement ele_SearchForRecord, ele_SearchTable, ele_firstRecord, ele_secondRecord, ele_CRMUser, ele_MktDropDown, ele_Contact, ele_New, ele_firstRecCheckbox, ele_secRecCheckbox, ele_TitleOuter, ele_TitleDropDown, ele_IetWebKey;

        IWebElement ele_FirstNameOuter, ele_FirstName, ele_LastNameOuter, ele_LastName, ele_MiddleNameOuter, ele_MiddleName, ele_DOBOuter, ele_DOB, ele_ContactTitleOuter, ele_ContactTitle, ele_HEmailOuter, ele_HEmail, ele_WEmailOuter, ele_WEmail, ele_prefEmailOuter, ele_prefEmailDropDown, ele_mobPhoneOuter, ele_mobPhone, ele_homePhoneOuter, ele_homePhone, ele_buPhoneOuter;

        IWebElement ele_buPhone, ele_addNameOuter, ele_addName, ele_street1Outer, ele_street1, ele_street2Outer, ele_street2, ele_street3Outer, ele_street3, ele_cityOuter, ele_city, ele_countyOuter, ele_county, ele_postalCodeOuter, ele_postalcode, ele_countryOuter, ele_country, ele_homeInvalid, ele_genderOuter, ele_genderDropDown;

        IWebElement ele_eduAddNameOuter, ele_eduAddName, ele_eduAddStreet1Outer, ele_eduAddStreet1, ele_eduAddStreet2Outer, ele_eduAddStreet2, ele_eduAddStreet3Outer, ele_eduAddStreet3, ele_eduAddCityOuter, ele_eduAddCity, ele_eduAddCountyOuter, ele_eduAddCounty, ele_eduAddPostalOuter, ele_eduAddPostal, ele_eduAddCountryOuter, ele_eduAddCountry;

        IWebElement ele_eduInvalid, ele_workAddNameOuter, ele_workAddName, ele_workAddStreet1Outer, ele_workAddStreet1, ele_workAddStreet2Outer, ele_workAddStreet2, ele_workAddStreet3Outer, ele_workAddStreet3, ele_workAddCityOuter, ele_workAddCity, ele_workAddCountyOuter, ele_workAddCounty, ele_workAddPostalOuter;

        IWebElement ele_workAddPostal, ele_workAddCountryOuter, ele_workAddCountry, ele_workInvalid, ele_ContactRefNo, ele_Salutation, ele_dialogFooterSaveBtn, ele_post, ele_postButton, ele_bothPostUserTitle, ele_bothPostAutoTitle, ele_autoPostLink, ele_autoPostTitle, ele_autoPostContact, ele_userPostLink;

        IWebElement ele_userPostTitle, ele_userPost, ele_NotesLink, ele_NotesTextArea, ele_notesAttachButton, notesBrowseButton, ele_notesPostButton, ele_NotesTextAfterUpload, ele_NotesAttachAfterUpload, ele_ActivitiesLink, ele_AddPhoneCallLink, ele_AddPhoneCallDesc, ele_AddPhoneCallOkBtn, ele_phoneCallWallFNLN, ele_phoneCallWallDesc;

        IWebElement ele_AddTaskLink, ele_TaskSubject, ele_TaskDescOuter, ele_TaskDesc, ele_TaskDueOuter, ele_TaskDueDate, ele_TaskDueTime, ele_TaskPriority, ele_AddTaskOkBtn, ele_TaskWallSub, ele_moreActivitiesBtn, ele_emailSubjectOuter, ele_emailSubject, ele_emailToOuter, ele_emailToDelete, ele_emailTo, ele_emailSearch, ele_emailDialog, ele_emailBody;

        IWebElement ele_ActivitiesEmailImg, ele_ActivitiesEmailSub, ele_appointSubject, ele_appointDescOuter, ele_appointDesc, ele_ActivitiesAppointImg, ele_appealSubject, ele_ActivitiesAppealImg;

        IWebElement ele_accomodateSubject, ele_ActivitiesAccomodateImg, ele_distLearnSubject, ele_ActivitiesDistLearnImg, ele_newHearingSubject, ele_ActivitiesNewHearingImg, ele_newInvestigationSubject;

        IWebElement ele_ActivitiesNewInvestigationImg, ele_ContactTabLink, ele_ContactExtSysIDLink, ele_AddNewExtSysID, ele_LinkOrgOuter, ele_ExtSysID, ele_ExtSysIDMenuItem, ele_SysIDOuter, ele_SysID, ele_contactDectivate, ele_dialogFooterDeactivateBtn, ele_contactSelContainer, ele_contactActivate;

        IWebElement ele_dialogFooterActivateBtn, ele_TaskIcon, ele_userTeamOuter, ele_userTeam, ele_userTeamMenu, ele_userTeamOkBtn, ele_Activities, ele_recSelect;

        IWebElement ele_leadSourceOuter, ele_leadSource, ele_leadSourceDropDown, ele_leadSearchImg, ele_LeadMenuItem;

        IWebElement ele_contactImportSourceOuter, ele_contactImportSource, ele_contatImportSourceDropDown, ele_contactImportSourceSearchImg, ele_contactImportSourceMenuItem, ele_SalConfirm;

        IWebElement ele_parentOrgOuter, ele_parentOrg, closeButton_yellowRibbon, ele_eduPhoneOuter, ele_eduPhone, ele_ietDetailstab;


        IJavaScriptExecutor executor;
        Config cf = new Config();

        #endregion

        public IE_Silverbear_Contact_PO(IWebDriver driver, IWait<OpenQA.Selenium.IWebDriver> iWait)
        {
            this.driver = driver;
            this.iWait = iWait;
        }
        #region Selector

        By MktDropDownContact = By.CssSelector("div#navTabGroupDiv>span.navBarTopLevelItem>span#TabSFA>a.navTabButtonLink");
        By Loading = By.CssSelector("span#LoadingImageLabel");
        By Contacts = By.XPath("//*[@id='nav_conts']/span[2]");
        // By Contacts = By.CssSelector("div#actionGroupControl>ul>li:nth-child(2)>span>span>span>span>li:nth-child(2)");
        By NewContact = By.CssSelector("div#crmTopBar>div#crmRibbonManager>div>ul>li>span>a>img");
        By NewContactHeader = By.CssSelector("span#TabNode_tab0Tab-main>a>span>span");
        By contentIFrame0 = By.Id("contentIFrame0");
        By SearchForRecord = By.CssSelector("input#crmGrid_findCriteria");
        By SearchGrid = By.CssSelector("table#gridBodyTable>tbody");
        By contentIFrame1 = By.Id("contentIFrame1");
        By SalesDropDown = By.CssSelector("span.navTabButtonArrowDown");
        By MoreInformationLink = By.CssSelector("span#moreAInfoContainer >a");
        By Go_on_to_the_webpageLink = By.LinkText("Go on to the webpage (not recommended)");
        By TitleOuter = By.CssSelector("div#sb_title>div");
        By Title = By.CssSelector("div#sb_title>div:nth-child(2)>select#sb_title_i");
        By FirstNameOuter = By.CssSelector("div#firstname>div");
        By FirstName = By.CssSelector("input#firstname_i");
        By LastNameOuter = By.CssSelector("div#lastname");
        By LastName = By.CssSelector("input#lastname_i");
        By DOB = By.CssSelector("input#birthdate_iDateInput");   //changed by diksha 18/05/2020
        By Street1ContactOuter = By.CssSelector("div#address1_line1");
        By Street1Contact = By.CssSelector("input#address1_line1_i");
        By CityContactOuter = By.CssSelector("div#address1_city");
        By CityContact = By.CssSelector("input#address1_city_i");
        By CountyContactOuter = By.CssSelector("div#address1_county");
        By CountyContact = By.CssSelector("input#address1_county_i");
        By PostalCodeContactOuter = By.CssSelector("div#address1_postalcode");
        By PostalCodeContact = By.CssSelector("input#address1_postalcode_i");
        By CountryContactOuter = By.CssSelector("div#address1_country");
        By CountryContact = By.CssSelector("input#address1_country_i");
        By HomeEmailOuter = By.CssSelector("div#emailaddress2");
        By HomeEmail = By.CssSelector("input#emailaddress2_i");
        By WorkEmailOuter = By.CssSelector("div#emailaddress3");
        By WorkEmail = By.CssSelector("input#emailaddress3_i");
        By EduEmailOuter = By.CssSelector("div#sb_educationemail");
        By EduEmail = By.CssSelector("input#sb_educationemail_i");
        By PAEmailOuter = By.CssSelector("div#sb_paemail");
        By PAEmail = By.CssSelector("input#sb_paemail_i");
        By PrefEmailOuter = By.CssSelector("div#sb_preferredemail");
        By PrefEmail = By.CssSelector("div#sb_preferredemail>div:nth-child(2)>select#sb_preferredemail_i");
        By BtnListContact = By.CssSelector("div#crmTopBar>div#crmRibbonManager>div>ul>li");
        //By BtnListContact = By.CssSelector("input.PSPUSHBUTTON");
        By SalutationWarn = By.CssSelector("span.PSTEXT");
        By ietDetails = By.LinkText("IET Details");



        #endregion


        public void HandleUnsecureWebsite()
        {
            driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
        }

        public void hideWindow()
        {
            driver.Manage().Window.Position = new Point(-2000, 0);

            driver.Manage().Window.Size = new Size(0, 0);

            Thread.Sleep(1000);
        }

        public void showWindow()
        {
            driver.Manage().Window.Position = new Point(0, 0);

            driver.Manage().Window.Maximize();
        }

        public static string GetPostData(string fromLanguage, string toLanguage, string text)
        {
            string data = string.Format("hl=en&ie=UTF8&langpair={0}%7C{1}&text=" + text + "#{0}/{1}/" + text, fromLanguage, toLanguage);

            return data;
        }




        public void redirectToContact(string operation)
        {

            try
            {
                Boolean jsActive;

                Thread.Sleep(70000);

                //closeButton_yellowRibbon = driver.FindElement(By.Id("crmAppMessageBarCloseButtonImage"));

                //Console.WriteLine("Yellow Ribbon found");

                //closeButton_yellowRibbon.Click();

                //Console.WriteLine("Yellow ribbon clicked");

                //Thread.Sleep(2000);

                driver.SwitchTo().DefaultContent();

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("div.navFloatRight>span#TabUserInfoId>a>span#navTabButtonChangeProfileImageLink>img")));

                IWebElement ele_profImage = driver.FindElement(By.CssSelector("div.navFloatRight>span#TabUserInfoId>a>span#navTabButtonChangeProfileImageLink>img"));

                ele_profImage.Click();

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("div.navUserInfoDropDownMenuContainer>span#navTabButtonUserInfoDropDownId>a#navTabButtonUserInfoUserNameId")));

                ele_CRMUser = driver.FindElement(By.CssSelector("div.navUserInfoDropDownMenuContainer>span#navTabButtonUserInfoDropDownId>a#navTabButtonUserInfoUserNameId"));

                string CRMUser = ele_CRMUser.GetAttribute("title");

                Console.WriteLine("CRM USER:" + CRMUser);

                //objConfig.writingIntoXML("SilverBearCRM", "Dashboard", "CRMUser", CRMUser, "SysConfig.xml");

                Thread.Sleep(2000);

                // Wait until 'Marketing Dropdown' is displayed on SilverBear CRM home page

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(MktDropDownContact));

                // Wait until content is loading on SilverBear CRM

                // iWait.Until(ExpectedConditions.InvisibilityOfElementLocated(Loading));

                // Get the 'Marketing Dropdown' object and click

                //ele_MktDropDown = driver.FindElement(By.CssSelector("div#navTabGroupDiv>span.navBarTopLevelItem>span#TabSFA>a.navTabButtonLink"));

                ele_MktDropDown = driver.FindElement(MktDropDownContact);
                //driver.FindElement(By.XPath("//*[@id=\"TabSFA\"]/a/span/img")).Click();

                Thread.Sleep(2000);

                ele_MktDropDown.Click();

                Thread.Sleep(2000);

                // Click on 'Contact' on Dropdown panel

                ele_Contact = driver.FindElement(Contacts);

                Thread.Sleep(2000);

                ele_Contact.Click();

                Thread.Sleep(6000);

                // Wait until content is loading on SilverBear CRM

                //iWait.Until(ExpectedConditions.InvisibilityOfElementLocated(Loading));  //changed by diksha 13/05/2020

                //jsActive = Helper.IsJavaScriptActive(driver);   //changed by diksha 13/05/2020

                //SConsole.WriteLine("JS Active 1" + jsActive);  //changed by diksha 13/05/2020

                log.Info("SilverBearCRM_01_SikuliCheck test completed" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());
            }

            catch (Exception e)
            {
                log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Console.WriteLine(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Assert.AreEqual(true, false);
            }

        }

        public void New_Contact()
        {
            try
            {

                DefaultWait<IWebDriver> waitNew = new DefaultWait<IWebDriver>(driver);

                waitNew.Timeout = TimeSpan.FromSeconds(60);
                waitNew.PollingInterval = TimeSpan.FromSeconds(10);
                waitNew.IgnoreExceptionTypes(typeof(NoSuchElementException));
                waitNew.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                waitNew.IgnoreExceptionTypes(typeof(InvalidElementStateException));

                //waitNew.Until(ExpectedConditions.ElementExists(NewContact));

                //waitNew.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(OR.readingXMLFile("Contact", "NewContact", "SilverBearCRM_OR.xml"))));

                // Click on 'New' icon

                ele_New = driver.FindElement(NewContact);   // Need to add wait for new in fluentwait

                ele_New.Click();

                Thread.Sleep(20000);

                Helper.AlertHandling(driver, "alert", null, null);

                //iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(Loading));

                Thread.Sleep(10000);

                //iWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(OR.readingXMLFile("Contact", "NewContactHeader", "SilverBearCRM_OR.xml"))));

                // iWait.Until(ExpectedConditions.ElementExists(NewContactHeader));
            }

            catch (Exception e)
            {
                log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Console.WriteLine(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Assert.AreEqual(true, false);
            }

        }

        public void Update_Contact()
        {
            try
            {

                DefaultWait<IWebDriver> waitUpdate = new DefaultWait<IWebDriver>(driver);

                waitUpdate.Timeout = TimeSpan.FromSeconds(60);
                waitUpdate.PollingInterval = TimeSpan.FromSeconds(10);
                waitUpdate.IgnoreExceptionTypes(typeof(NoSuchElementException));
                waitUpdate.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                waitUpdate.IgnoreExceptionTypes(typeof(InvalidElementStateException));

                waitUpdate.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(NewContact));

                waitUpdate.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(NewContact));

                // Update Operation

                Console.WriteLine("Update operation started");

                driver.SwitchTo().Frame(driver.FindElement(contentIFrame0));

                IList<string> contactDetails = objConfig.readSysConfigFile("SilverBearCRM", "Contact", "SysConfig.xml");

                string updateRecord = contactDetails.ElementAt(0).ToString() + " " + contactDetails.ElementAt(1).ToString();

                Console.WriteLine("Update Record " + updateRecord);

                ele_SearchForRecord = driver.FindElement(SearchForRecord);

                ele_SearchForRecord.SendKeys(updateRecord);

                ele_SearchForRecord.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(2000);

                // Wait until search table is loaded in search grid

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(SearchGrid));

                ele_SearchTable = driver.FindElement(SearchGrid);

                recordSize = ele_SearchTable.FindElements(By.TagName("tr")).Count;

                if (recordSize < 1)
                {
                    Console.WriteLine("No Record present for entered search criteria");

                    log.Info("No Record present for entered search criteria");

                    Assert.AreEqual(true, false);
                }
                else
                {

                    ele_firstRecord = ele_SearchTable.FindElements(By.TagName("tr")).ElementAt(0);  // Get the first record from search table

                    string contactRefNo = ele_firstRecord.FindElement(By.CssSelector("td:nth-child(12) span")).Text.ToString();  // changed the td:nth-child(2) to td:nth-child(12) as contact reference column is posited at 12th

                    Console.WriteLine("Contact Ref No. is" + contactRefNo);

                    Assert.That(contactDetails.ElementAt(48).ToString(), Is.EqualTo(contactRefNo.Trim().ToString()).IgnoreCase); // Verify the contact ref no. is correct for search record in grid

                    // Click on searched record for update

                    ele_firstRecord.FindElement(By.CssSelector("td:nth-child(2) a")).Click(); //changed td:nth-child(3) a to td:nth-child(2) a

                    Helper.AlertHandling(driver, "alert", null, null);

                    iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(Loading));

                    iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(NewContactHeader));

                }
            }

            catch (Exception e)
            {
                log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Console.WriteLine(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Assert.AreEqual(true, false);
            }
        }

        public void RetentionArch_Contact()
        {
            try
            {

                Console.WriteLine("Contact Retention & Archiving Operation Started");

                DefaultWait<IWebDriver> waitRetention = new DefaultWait<IWebDriver>(driver);

                waitRetention.Timeout = TimeSpan.FromSeconds(60);
                waitRetention.PollingInterval = TimeSpan.FromSeconds(10);
                waitRetention.IgnoreExceptionTypes(typeof(NoSuchElementException));
                waitRetention.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                waitRetention.IgnoreExceptionTypes(typeof(InvalidElementStateException));

                waitRetention.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(NewContact));

                waitRetention.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(NewContact));

                driver.SwitchTo().Frame(driver.FindElement(contentIFrame0));

                ele_SearchForRecord = driver.FindElement(SearchForRecord);

                ele_SearchForRecord.SendKeys(searchRec);

                ele_SearchForRecord.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(2000);

                // Wait until search table is loaded in search grid

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(SearchGrid));

                ele_SearchTable = driver.FindElement(SearchGrid);

                recordSize = ele_SearchTable.FindElements(By.TagName("tr")).Count;

                if (recordSize < 2)
                {
                    Console.WriteLine("Multiple records are not present for entered search criteria");

                    log.Info("Multiple records are not present for entered search criteria");

                    Assert.AreEqual(true, false);
                }
                else
                {
                    // Select Records to Deactivate

                    ele_firstRecord = ele_SearchTable.FindElements(By.TagName("tr")).ElementAt(0);  // Get the first record from search table

                    ele_secondRecord = ele_SearchTable.FindElements(By.TagName("tr")).ElementAt(1); // Get the second record from search table

                    Helper.IsJavaScriptActive(driver);

                    contactRefNoRec0 = ele_firstRecord.FindElement(By.CssSelector("td:nth-child(2)")).Text.ToString();

                    contactRefNo1 = ele_firstRecord.FindElement(By.CssSelector("td:nth-child(12)>nobr>span")).Text.ToString();

                    contactRefNoRec1 = ele_secondRecord.FindElement(By.CssSelector("td:nth-child(2)")).Text.ToString();

                    contactRefNo2 = ele_secondRecord.FindElement(By.CssSelector("td:nth-child(12)>nobr>span")).Text.ToString();

                    Console.WriteLine("Contact Ref No. First Rec is" + contactRefNo1);

                    Console.WriteLine("Contact Ref No. Second Rec is" + contactRefNo2);

                    Console.WriteLine("Contact Ref name. First Rec is" + contactRefNoRec0);

                    Console.WriteLine("Contact Ref Name. Second Rec is" + contactRefNoRec1);

                    // Select first and second record for deactivate

                    ele_firstRecCheckbox = ele_firstRecord.FindElement(By.CssSelector("td:nth-child(1)"));

                    ele_secRecCheckbox = ele_secondRecord.FindElement(By.CssSelector("td:nth-child(1)"));

                    ele_firstRecCheckbox.Click();

                    Thread.Sleep(2000);

                    ele_secRecCheckbox.Click();

                    Thread.Sleep(2000);

                }
            }

            catch (Exception e)
            {
                log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Console.WriteLine(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Assert.AreEqual(true, false);
            }
        }

        public void VerifyWebKey()
        {

            int searchTryCnt = 0;

            Boolean cntFound = false;

            driver.SwitchTo().DefaultContent();

            iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(SalesDropDown));

            IWebElement ele_salesDropDown = driver.FindElement(SalesDropDown);

            // Wait until content is loading on SilverBear CRM

            //iWait.Until(ExpectedConditions.InvisibilityOfElementLocated(Loading));  //changed by diksha 18/05/2020

            // Get the 'Marketing Dropdown' object and click

            ele_salesDropDown.Click();

            // Click on 'Contact' on Dropdown panel

            ele_Contact = driver.FindElement(Contacts);

            ele_Contact.Click();

            // Wait until content is loading on SilverBear CRM

            //iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(Loading));

            DefaultWait<IWebDriver> waitUpdate = new DefaultWait<IWebDriver>(driver);

            waitUpdate.Timeout = TimeSpan.FromSeconds(60);
            waitUpdate.PollingInterval = TimeSpan.FromSeconds(10);
            waitUpdate.IgnoreExceptionTypes(typeof(NoSuchElementException));
            waitUpdate.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            waitUpdate.IgnoreExceptionTypes(typeof(InvalidElementStateException));

            Thread.Sleep(2000);

            waitUpdate.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(NewContact));

            // // waitUpdate.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(OR.readingXMLFile("Contact", "NewContact", "SilverBearCRM_OR.xml"))));

            // Search and Verify operation

            driver.SwitchTo().Frame(driver.FindElement(contentIFrame0));

            Thread.Sleep(2000);

            IList<string> contactDetails = cf.readSysConfigFile("SilverBearCRM", "Contact", "SysConfig.xml");

            string contRefName = contactDetails.ElementAt(48).ToString();

            Thread.Sleep(3000);

            Console.WriteLine("Data Verification for Contact Module Started on PeopleSoft");

            Console.WriteLine("Contact Ref. No. is:" + contRefName);

            while (searchTryCnt < 10)
            {
                ele_SearchForRecord = driver.FindElement(SearchForRecord);

                //ele_SearchForRecord.Clear();

                ele_SearchForRecord.SendKeys(contRefName);

                ele_SearchForRecord.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(2000);

                // Wait until search table is loaded in search grid

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(SearchGrid));

                ele_SearchTable = driver.FindElement(SearchGrid);

                recordSize = ele_SearchTable.FindElements(By.TagName("tr")).Count;

                if (recordSize == 1)
                {
                    cntFound = true;

                    break;
                }

                searchTryCnt++;

                Thread.Sleep(4000);
            }

            if (cntFound)
            {
                Console.WriteLine("Searched Record is found in SilverBear CRM");

                ele_firstRecord = ele_SearchTable.FindElements(By.TagName("tr")).ElementAt(0);  // Get the first record from search table

                ele_firstRecord.FindElement(By.CssSelector("td:nth-child(2)")).Click();

                Thread.Sleep(7000);

                //iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(Loading));

                iWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(NewContactHeader));

                driver.SwitchTo().DefaultContent();

                driver.SwitchTo().Frame(driver.FindElement(contentIFrame1));

                //ele_IetWebKey = driver.FindElement(By.CssSelector("div#sbiet_ietwebkey>div>span"));

                ele_IetWebKey = driver.FindElement(By.Id("IET Web Key_label"));   //changed by diksha 26/03/2020
                bool contactRefCheck = true;

                string contactIETWebKey = null;

                Helper.ScrollToViewElement(ele_IetWebKey, driver);

                contactIETWebKey = ele_IetWebKey.Text.ToString();


                contactRefCheck = Regex.IsMatch(contactIETWebKey, "[0-9]");

                StringAssert.IsMatch("[0-9]", contactIETWebKey);
            }
            else
            {
                Console.WriteLine("Searched contact not found in SilverBear CRM");

                log.Info("Searched contact not found in Darwin CRM");

                Assert.AreEqual(true, false);
            }

        }

        public void fillMandatoryFields(string operation)
        {

            try
            {
                int option;

                //string fromLanguage = "English", toLanguage = "Chinese", addText = "Address";

                string addType = "PlainAdd";

                //if (addType.Equals("MandarinAdd"))
                //{
                //    Console.WriteLine("---------- Calling Langugae Translator -----");

                //    transResult = langTranslator(fromLanguage, toLanguage, addText);

                //    Console.WriteLine("Langugae Trnslator Result:" + transResult);
                //}



                //IList<string> contDetails = objConfig.readSysConfigFile("SilverBearCRM", "Contact", "SysConfig.xml");

                driver.SwitchTo().DefaultContent();

                driver.SwitchTo().Frame(driver.FindElement(contentIFrame1));

                Thread.Sleep(3000);

                ///////////////////////////////////////////// Title ///////////////////////////////////////////////////////////

                ele_TitleOuter = driver.FindElement(TitleOuter);

                IList<IWebElement> ele_titledropdown = driver.FindElements(Title);

                if (ele_titledropdown.Count == 0)
                {
                    ele_TitleOuter.Click();
                }


                Thread.Sleep(1000);

                ele_TitleDropDown = driver.FindElement(Title);

                option = Helper.getRandom(10);

                Thread.Sleep(5000);

                SelectElement ele_TitleSelect = new SelectElement(ele_TitleDropDown);

                IList<IWebElement> titleOptions = ele_TitleSelect.Options;

                if (operation.Equals("New"))
                {
                    //ele_TitleSelect.SelectByIndex(option);

                    ele_TitleSelect.SelectByText("Mr");
                }
                else
                {
                    ele_TitleSelect.SelectByText("Miss");
                }
                Thread.Sleep(2000);

                string title = driver.FindElement(By.CssSelector("div#sb_title>div>label")).Text.ToString();

                if (ele_TitleOuter.Displayed)
                {
                    ele_TitleOuter.SendKeys(OpenQA.Selenium.Keys.Tab);
                }

                Console.WriteLine("Title selected -->" + Title);
                ////////////////////To////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////// First Name //////////////////////////////////////////////////////////

                Thread.Sleep(2000);
                ele_FirstNameOuter = driver.FindElement(FirstNameOuter);

                ele_FirstNameOuter.Click();

                iWait.Until(ExpectedConditions.ElementIsVisible(FirstName));

                ele_FirstName = driver.FindElement(FirstName);

                ele_FirstName.Clear();  // Clear already present First Name

                string firstGuid = Helper.GetGuid().ToString();

                if (operation.Equals("New"))
                {
                    firstName = "AUTO-USR-FN-" + firstGuid.Remove(10);
                }
                else
                {
                    firstName = "AUTO-UPD-FN-" + firstGuid.Remove(10);
                }

                ele_FirstName.SendKeys(firstName);
                //ele_FirstName.Click();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////// Last Name ////////////////////////////////////////////////////////

                ele_LastNameOuter = driver.FindElement(LastNameOuter);

                ele_LastNameOuter.Click();

                iWait.Until(ExpectedConditions.ElementIsVisible(LastName));

                ele_LastName = driver.FindElement(LastName);

                ele_LastName.Clear();

                string lastGuid = Helper.GetGuid().ToString();

                if (operation.Equals("New"))
                {
                    lastName = "AUTO-USR-LN-" + lastGuid.Remove(10);
                }
                else
                {
                    lastName = "AUTO-UPD-LN-" + lastGuid.Remove(10);
                }

                ele_LastName.SendKeys(lastName);

                Thread.Sleep(2000);



                //////////////////////////////////////////////DOB//////////////////////////////////////////////////////////


                ele_DOBOuter = driver.FindElement(By.Id("birthdate"));

                ele_DOBOuter.Click();

                Thread.Sleep(4000);

                //iWait.Until(ExpectedConditions.ElementIsVisible(DOB));

                ele_DOB = driver.FindElement(DOB);

                //ele_DOB.Click();

                //ele_DOB.Clear();

                string dOB;

                Console.WriteLine("DOB cleared......");

                if (operation.Equals("New"))
                {
                    dOB = "23/04/1975";
                }
                else
                {
                    dOB = "15/04/1975";
                }

                ele_DOB.SendKeys(dOB);

                ele_DOB.SendKeys(OpenQA.Selenium.Keys.Tab);

                Thread.Sleep(2000);

                log.Info("DOb added" + DOB);




                //Thread.Sleep(5000);

                /////////////////////////////////////// Street 1 /////////////////////////////////////////////

                ele_street1Outer = driver.FindElement(Street1ContactOuter);

                //uf.scrollIntoView(driver, ele_street1Outer);

                Thread.Sleep(2000);

                ele_street1Outer.Click();

                //uf.alertHandling(driver, "alert", null, null);

                iWait.Until(ExpectedConditions.ElementIsVisible(Street1Contact));

                ele_street1 = driver.FindElement(Street1Contact);

                ele_street1.Clear();

                if (operation.Equals("New"))
                {
                    if (addType.Equals("MandarinAdd"))
                    {
                        street1 = transResult;
                    }
                    else
                    {
                        street1 = "AUTO-USR-New-Street1";
                    }
                }
                else
                {
                    street1 = "AUTO-USR-Update-Street1";
                }

                ele_street1.SendKeys(street1);

                ele_street1.SendKeys(OpenQA.Selenium.Keys.Tab);

                /////////////////////////////////////////////////////////////////////////////////////////////


                Thread.Sleep(2000);


                //////////////////////////////////// City ///////////////////////////////////////////////////////////////////////////////////////////////

                ele_cityOuter = driver.FindElement(CityContactOuter);

                ele_cityOuter.Click();

                Helper.AlertHandling(driver, "alert", null, null);

                iWait.Until(ExpectedConditions.ElementIsVisible(CityContact));

                ele_city = driver.FindElement(CityContact);

                ele_city.Clear();

                if (operation.Equals("New"))
                {
                    if (addType.Equals("MandarinAdd"))
                    {
                        city = transResult;
                    }
                    else
                    {
                        city = "AUTO-USR-New-City";
                    }
                }
                else
                {
                    city = "AUTO-USR-Update-City";
                }

                ele_city.SendKeys(city);

                Thread.Sleep(2000);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ///////////////////////////////////// County //////////////////////////////////////////////////////////////////////////////////////////

                ele_countyOuter = driver.FindElement(CountyContactOuter);

                ele_countyOuter.Click();

                Helper.AlertHandling(driver, "alert", null, null);

                iWait.Until(ExpectedConditions.ElementIsVisible(CountyContact));

                ele_county = driver.FindElement(CountyContact);

                ele_county.Clear();

                if (operation.Equals("New"))
                {

                    if (addType.Equals("MandarinAdd"))
                    {
                        county = transResult;
                    }
                    else
                    {
                        county = "BRIST";
                    }
                }
                else
                {
                    county = "STB";
                }

                ele_county.SendKeys(county);
                Thread.Sleep(2000);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                /////////////////////////////////// Postal Code //////////////////////////////////////////////////////////////////////////////////////

                Thread.Sleep(2000);

                ele_postalCodeOuter = driver.FindElement(PostalCodeContactOuter);

                ele_postalCodeOuter.Click();

                Helper.AlertHandling(driver, "alert", null, null);

                iWait.Until(ExpectedConditions.ElementIsVisible(PostalCodeContact));

                ele_postalcode = driver.FindElement(PostalCodeContact);

                ele_postalcode.Clear();

                if (operation.Equals("New"))
                {
                    if (addType.Equals("MandarinAdd"))
                    {
                        postalcode = transResult;
                    }
                    else
                    {
                        postalcode = "SG1 2AY";
                    }
                }
                else
                {
                    postalcode = "LU1 1AA";
                }

                ele_postalcode.SendKeys(postalcode);

                ele_postalcode.SendKeys(OpenQA.Selenium.Keys.Tab);


                Thread.Sleep(2000);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////// Country //////////////////////////////////////////////////////////////////////////////////////////

                ele_countryOuter = driver.FindElement(CountryContactOuter);

                ele_countryOuter.Click();

                Helper.AlertHandling(driver, "alert", null, null);

                iWait.Until(ExpectedConditions.ElementIsVisible(CountryContact));

                ele_country = driver.FindElement(CountryContact);

                ele_country.Clear();

                if (operation.Equals("New"))
                {

                    country = "United Kingdom";
                }
                else
                {
                    country = "France";
                }

                ele_country.SendKeys(country);

                ele_country.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(2000);

                /////////////////// Home email address ///////////////////////////


                ele_HEmailOuter = driver.FindElement(HomeEmailOuter);

                homeEmail = firstGuid.Remove(10) + "homenew@test.com";

                if (operation.Equals("New"))
                {
                    ele_HEmailOuter.Click();

                    iWait.Until(ExpectedConditions.ElementIsVisible(HomeEmail));

                    ele_HEmail = driver.FindElement(HomeEmail);

                    ele_HEmail.Clear();

                    homeEmail = firstGuid.Remove(10) + "homenew@test.com";

                    ele_HEmail.SendKeys(homeEmail);

                    Thread.Sleep(2000);
                }
                else
                {
                    //ele_ContactTitleOuter = driver.FindElement(By.CssSelector(OR.readingXMLFile("Contact", "ContactTitleOuter", "SilverBearCRM_OR.xml")));

                    //ele_ContactTitleOuter.Click();

                    //ele_ContactTitle = driver.FindElement(By.CssSelector(OR.readingXMLFile("Contact", "ContactTitle", "SilverBearCRM_OR.xml")));

                    //ele_ContactTitle.SendKeys(OpenQA.Selenium.Keys.Tab);

                    IWebElement ele_GenderOuter = driver.FindElement(By.CssSelector("div#gendercode"));

                    ele_GenderOuter.Click();

                    ele_GenderOuter.SendKeys(OpenQA.Selenium.Keys.Tab);

                    //IWebElement ele_Gender = driver.FindElement(By.CssSelector("select#gendercode_i"));

                    //SelectElement ele_genderDropDown = new SelectElement(ele_Gender);

                    //ele_genderDropDown.SelectByText("Female");

                    //ele_Gender.SendKeys(OpenQA.Selenium.Keys.Tab);

                    IWebElement ele_preferredemailaddress = driver.FindElement(By.CssSelector("div#emailaddress1"));

                    Thread.Sleep(5000);

                    ele_preferredemailaddress.SendKeys(OpenQA.Selenium.Keys.Tab);

                    Thread.Sleep(5000);

                    ele_HEmail = driver.FindElement(HomeEmail);

                    ele_HEmail.Clear();

                    homeEmail = firstGuid.Remove(10) + "homeupdate@test.com";

                    ele_HEmail.SendKeys(homeEmail);

                }




            }
            catch (Exception e)
            {
                log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Console.WriteLine(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Assert.AreEqual(true, false);
            }

        }

        public void saveContact(string operation)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                
                IList<IWebElement> btnList = driver.FindElements(BtnListContact);

                Console.WriteLine("Total header elements:=" + btnList.Count);

                Console.WriteLine("First Element:" + btnList.ElementAt(0).GetAttribute("title").ToString());

                Thread.Sleep(2000);

                btnList.ElementAt(0).Click();
                //IWebElement menubar = driver.FindElement(By.ClassName("ms-crm-CommandBar-Menu"));

                //Thread.Sleep(2000);

                //Helper.ScrollToViewElement(menubar, driver);

                //IList<IWebElement> btnList = driver.FindElements(BtnListContact);

                //IWebElement btnList = driver.FindElement(BtnListContact);

                Thread.Sleep(2000);

                // IList<IWebElement> btnList = driver.FindElements(By.CssSelector("ul.ms-crm-CommandBar-Menu > li"));

                Thread.Sleep(2000);

                //By.CssSelector("input.PSPUSHBUTTON").ElementAt(0).Click();

                //To store darwin webkey

                if (operation.Equals("New"))
                {
                    newContactURL = driver.Url.ToString();

                    Console.WriteLine("New Contact URL on Save" + newContactURL);
                    //Thread.Sleep(5000);

                    //Helper.ScrollToViewElement(driver.FindElement(ietDetails), driver);

                    //Thread.Sleep(2000);

                    //ele_ietDetailstab = driver.FindElement(By.LinkText("IET Details"));

                    //ele_ietDetailstab.Click();

                    //Thread.Sleep(2000);

                    //DarwinKey = driver.FindElement(By.CssSelector("table.PSLEVEL1SCROLLAREABODY>tbody>tr:nth-child(7)>td:nth-child(2)>span")).Text;

                    //Thread.Sleep(1000);

                    //IWebElement ele_PersonTab = driver.FindElement(By.LinkText("Person"));

                    //ele_PersonTab.Click();

                    //Thread.Sleep(1000);

                }


                if (operation.Equals("Update"))
                {
                    iWait.Until(ExpectedConditions.ElementExists(SalutationWarn));

                    ele_SalConfirm = driver.FindElement(SalutationWarn).FindElement(By.CssSelector("input.PSPUSHBUTTONTBOK"));

                    ele_SalConfirm.Click();

                    Thread.Sleep(4000);
                }



            }
            catch (Exception e)
            {
                log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Console.WriteLine(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                Assert.AreEqual(true, false);
            }

        }

    }
}
