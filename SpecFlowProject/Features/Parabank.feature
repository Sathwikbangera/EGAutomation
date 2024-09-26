Feature: Parabank Register functionality

Feature to test the login functionality

Background:  
	Given User opens bank website


@register
Scenario Outline: Verify register functionality
	Given User clicks new register button
	When User enters the "<fname>","<lname>","<address>","<city>","<state>","<zip>","<phone>","<ssn>","<username>" ,"<password>","<cpassword>"
	And User clicks on register button
	Then User is navigated to Dashboard Page

Examples: 
| fname | lname | address | city | state | zip | phone | ssn | username | password | cpassword |
| sa    | ba    | sa      | s    | KA    | 12  | 12    | 112 | sa       | Sa@12    | Sa@12     |
| shu   | sha   | mijar   | BC   | KA    | 13  | 34    | 113 | sb       | Sb@13    | Sb@13     |

@login
Scenario Outline: Verify login functionality
	When User enters the "<user>" ,"<pass>"
	And User clicks on the login button
	Then User is navigated to Home Page

Examples: 
| user | pass |
| sa       | Sa@12    |
| sb       | Sb@13    |

