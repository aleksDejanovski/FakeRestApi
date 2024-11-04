Feature: Users

A short summary of the feature


Scenario: Get all users => HTTP 200 and check response
	When I call the get all users endpoint
	Then The response code is HTTP 200
	And The response contains "User 4"


Scenario: Get specific user => HTTP 200 And check response contains that id and that user
	When I call the Get users/{id} endpoint using id as 6
	Then The response code is HTTP 200
	And The response contains "User 6"
	And The response password property has value "Password6"
	

Scenario: Get user that does not exists in the data base => HTTP 404 and check response title content
	When I call the Get users/{id} endpoint using id as 5555
	Then The response code is HTTP 404
	And The response contains "Not Found"