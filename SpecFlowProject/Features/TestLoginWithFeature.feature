
Feature: TestLoginWithFeature

Test login with test data parameters

Background: 
	Given User is on login page

@Sanity
Scenario: Verify login functionality
	
	When User enters the username and password
	And User clicks on login button
	Then User is navigated to home page
@Regression
Scenario Outline: verify login fuctionality
	When User enters the "<username>" and "<password>"
	And User clicks on login button
	Then User is navigated to home page
	Then user selected city and country infomation
	| city   | country |
	| Delhi  | India   |
	| Boston | USA     |

Examples: 

	| username | password |
	| tom      | Harry    |
	| jerry    | Mathew   |

