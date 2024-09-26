Feature: Test Login functionality

Feature to test the login functionality

Scenario: Verify login functionality
	Given User is on login page
	When User enters the username and password
	And User clicks on login button
	Then User is navigated to home page
