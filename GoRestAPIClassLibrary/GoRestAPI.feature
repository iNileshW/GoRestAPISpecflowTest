Feature: Go Rest API Test
	In order to test api
	As a user
	want to check get response

@getusers
Scenario: Get JSON API response status code and record count
	Given user has an endpoint
	When get request with 'json' header format is sent to endpoint 'users'
	Then api response is with ok status
	And with correct count in api response

@getusers
Scenario: Get XML API response status code and record count
	Given user has an endpoint
	When get request with 'xml' header format is sent to endpoint 'users'
	Then api response is with ok status
	And with correct count in api response