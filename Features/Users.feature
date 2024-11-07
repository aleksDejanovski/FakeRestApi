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


Scenario: Create new user => HTTP 200 and check if response contains the create request data
	When I call the POST users endpoint using id as "25", username as "testuser" and password as "testpass" 
	Then The response code is HTTP 200
	And The response contains "testuser"
	And The response password property has value "testpass"


Scenario:  Create new user sending only username => HTTP 400 and check error message
	When I create a new user sending only "nameuser" as a username
	Then The response code is HTTP 400
	And The response contains "One or more validation errors occurred"


Scenario: Create new user sending only id as body => HTTP 200 and check if response contains the id
	When I create a new user sending 443 as id
	Then The response code is HTTP 200
	And The response contains "443"


Scenario: Update e user and change his password => HTTP 200 and check if response contains the changed password
	When I Update a user with a id of 64 and add set a username as "updatedName" and password as "updatedPass"
	Then The response code is HTTP 200
	And The response password property has value "updatedPass"


Scenario: Delete specific user => HTTP 200 
	When I delete a user with an id of 42
	Then The response code is HTTP 200


Scenario: Test complete CRUD Flow
	When I call the POST users endpoint using id as "43", username as "user12" and password as "pass12" 
	Then The response code is HTTP 200
	And The response contains "user12"
	When I Update a user with a id of 43 and add set a username as "user11223" and password as "newpass"
	Then The response code is HTTP 200
	And The response contains "user11223"
	And The response password property has value "newpass"
	When I call the Get users/{id} endpoint using id as 43
	Then The response code is HTTP 200
	Then The response password property has value "newpass"
	When I delete a user with an id of 43
	Then The response code is HTTP 200
	When I call the Get users/{id} endpoint using id as 43
	Then The response code is HTTP 404



