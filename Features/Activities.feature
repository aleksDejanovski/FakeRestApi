Feature: Activities

A short summary of the feature

@tag1
Scenario: Get all Activities => HTTP 200
	When I call the endpoint get all activities
	Then The response code is HTTP 200


Scenario: Get specific activity for given id => HTTP 200 and check response content
	When I call the endpoint get activity and use 3 as id
	Then The response code is HTTP 200
	And The response contains "Activity 3"
	And The property title has value "Activity 3"


Scenario: Get Specific activity for given id and check value that is not there => HTTP 200 and check response not containing
	When I call the endpoint get activity and use 6 as id
	Then The response code is HTTP 200
	And The property title does not have value "Activity 5"


Scenario: Get activity using 0 as an activity Id => HTTP 404 not found and check response content
	When I call the endpoint get activity and use 0 as id
	Then The response code is HTTP 404
	And The response contains "Not Found"


Scenario: Get activity using large number as activity id => HTTP 404 
	When I call the endpoint get activity and use 444444 as id
	Then The response code is HTTP 404
	And The response contains "Not Found"


	
