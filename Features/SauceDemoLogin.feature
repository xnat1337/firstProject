Feature: SauceDemo

A short summary of the feature

Background: Navigate to sauce demo login
	Given I navigate to sauce demo login page

	
Scenario: Verify Sauce Demo Login With Correct User Password Works
	Given I enter login credentials
	When I click submit button
	Then I see inventory page


Scenario Outline: Verify correct error displays when wrong credentials entered
	When I enter invalid credentials '<username>' / '<password>'
	And I click submit button
	Then '<error>' message is diplayed
Examples:
	| username       | password       | error                                                                     |
	| wrong_username | secret_sauce   | Epic sadface: Username and password do not match any user in this service |
	| standard_user  | wrong_password | Epic sadface: Username and password do not match any user in this service |
	|                | secret_sauce   | Epic sadface: Username is required                                        |
	| standard_user  |                | Epic sadface: Password is required                                        |


Scenario: Verify Sauce Demo Logout Work
Given 
		