Feature: IE_Silverbear_Contact
	
Background: 
Given  I login with System Admin
And I click on Contact link



@mytag
Scenario: 01 SilverBearCRM_TS1_01_CreateContactMandatoryOnlyInSilverBear  
This test creates contact with mandatory fields in SilverBear CRM and verifies it in Silverbear only
	
	When I click on "New" link
	And  I Fill all the mandatory fields Title,First Name,Last Name,DOB,Street 1,City,County,Postal Code,Country,Home email address 
	And  I click on "Save" button of Contact page 
	Then I verify the contact fields with web key field
