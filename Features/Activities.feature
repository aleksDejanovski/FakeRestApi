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


Scenario: Create new activity using valid data => HTTP 200 And check response content
	When I send POST request to the /Activities endpoint using id as 231 and title as "testTitle"
	Then The response code is HTTP 200
	And The response contains "231"
	And The property title has value "testTitle"



Scenario: Create new activity sending only id as body => HTTP 400 and check content error message
	When I send POST request to the /Activities endpoint using id as "432" only as a body
	Then The response code is HTTP 400
	And The response contains "The JSON value could not be converted to System.Boolean."


Scenario: Create new activity but sending title as empty string => HTTP 200 and check response
	When I send POST request to the /Activities endpoint using id as 455 and title as ""
	Then The response code is HTTP 200
	And The response contains "455"


Scenario Outline: Check system response for different sent Id => Check respose for Id content
	When I send POST request to the /Activities endpoint using id as <id> and title as "testTitle"
	Then The response code is HTTP 200
	And The response id has a value of <responseId>

Examples: 
| id  | responseId |
| 234 | 234        |
| 452 | 452        |
| 23  | 23         |
| 92  | 92         |


Scenario: Update given activity using valid data => HTTP 200 And check if response title is updated
	When I send PUT request to the Activities/{id} endpoint using id as 26 and title as "test12" and completed as false
	Then The response code is HTTP 200
	And The property title has value "test12"

	
	


	
