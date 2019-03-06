Feature: As demo user to PHPTravel site I am able to book hotel flight and tour

@mytag
Scenario: Add a hotel booking1
Given user launches PHP Travel website
When user enters username and password
Then user login successfully
And user searches a hotel in "New York" for future date
And user selects first search result
When user click on book
Then user receives an invoice