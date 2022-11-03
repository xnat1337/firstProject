Feature: API

A short summary of the feature

Scenario: Verify User Can Create New User
	When a user do POST request to "/user"
	Then status code "200" is returned
	And response contains correct user data
