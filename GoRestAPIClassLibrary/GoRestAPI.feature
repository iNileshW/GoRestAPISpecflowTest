Feature: Go Rest API Test
	In order to test api
	As a user
	want to check get response

@getUsers
Scenario: Get JSON API response and validate users count
	Given user has an endpoint
	When get request with 'json' header format is sent to endpoint 'users'
	Then api response is with ok status
	And validate count in api response

@getUsers
Scenario: Get XML API response and validate users count
	Given user has an endpoint
	When get request with 'xml' header format is sent to endpoint 'users'
	Then api response is with ok status
	And validate count in api response

@getAlbum
Scenario: Get JSON API response status and album count
	Given user has an endpoint
	When get request with 'json' header format is sent to endpoint 'albums'
	Then api response is with ok status
	And validate album count in api response
	And validate api response is for requested id