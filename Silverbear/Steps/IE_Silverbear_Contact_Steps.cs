using Silverbear.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Silverbear.Steps
{
    [Binding]
    public sealed class IE_Silverbear_Contact_Steps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        //private readonly ScenarioContext context;

        //public IE_Silverbear_Contact_Steps(ScenarioContext injectedContext)
        //{
        //    context = injectedContext;
        //}

        [Given(@"I login with System Admin")]
        public void GivenILoginWithSystemAdmin()
        {
            Objects.objLogin_PO.login("System Admin");
        }

        [Given(@"I click on Contact link")]
        public void GivenIClickOnContactLink()
        {
            Objects.ObjSilverbear_Contact_PO.redirectToContact("New");
        }

        [When(@"I click on ""(.*)"" link")]
        public void WhenIClickOnLink(string p0)
        {
            Objects.ObjSilverbear_Contact_PO.New_Contact();
        }

        [When(@"I Fill all the mandatory fields Title,First Name,Last Name,DOB,Street (.*),City,County,Postal Code,Country,Home email address")]
        public void WhenIFillAllTheMandatoryFieldsTitleFirstNameLastNameDOBStreetCityCountyPostalCodeCountryHomeEmailAddress(int p0)
        {
            Objects.ObjSilverbear_Contact_PO.fillMandatoryFields("New");
        }

        [When(@"I click on ""(.*)"" button of Contact page")]
        public void WhenIClickOnButtonOfContactPage(string p0)
        {
            Objects.ObjSilverbear_Contact_PO.saveContact("New");
        }

        [Then(@"I verify the contact fields with web key field")]
        public void ThenIVerifyTheContactFieldsWithWebKeyField()
        {
            Objects.ObjSilverbear_Contact_PO.VerifyWebKey();
        }
    
    }
}
