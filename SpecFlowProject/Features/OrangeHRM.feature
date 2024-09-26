Feature: OrangeHRM functionality

Test Orange HRM Website login functionality.
@tag1
Scenario: Verify login for Orange HRM Website
	Given User is on the Orange HRM Login Page
	When User enters the "<user>" and "<pass>" in input field.
	When User clicks on Login button
	Then User is navigated to Orange hrm home page


Examples: 
	| user  | pass     |
	| Admin | admin123 |


Scenario: Verify Inavlid login for Orange HRM Website
	Given User is on the Orange HRM Login Page
	When User enters the "<username>" and "<password>" in input field.
	When User clicks on Login button
	Then User is displayed with error message
Examples: 
	| username  | password     |
	| ssjjsj	| vaahaha		|

