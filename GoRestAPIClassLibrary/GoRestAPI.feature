Feature: Go Rest API Test
	In order to test api
	As a user
	want to check get response

@getUsers @users
Scenario Outline: Get API response and validate users count
	Given user has an endpoint
	When get request with <format> header format is sent to endpoint <endpoint>
	Then api response is with ok status
	And validate count in api response
Examples:
| format | endpoint |
| json   | users    |
| xml    | users    |

@getAlbum @albums
Scenario: Get JSON API response status and album count
	Given user has an endpoint
	When get request with 'json' format is sent to endpoint 'albums'
	Then api response is with ok status
	And validate album count in api response
	And validate api response is for requested id

@getAlbum @albums
Scenario: Get xml API response status and album count
	Given user has an endpoint
	When get request with 'xml' format is sent to endpoint 'albums'
	Then api response is with ok status
	And validate album count in api response
	And validate api response is for requested id


@getAlbum
Scenario Outline: Get API response status and album count
	Given user has an endpoint
	When get request with <format> header format is sent to endpoint <endpoint>
	Then api response is with ok status
	And validate album count in api response
	And validate api response is for requested id

Examples:
| format | endpoint  |
| json   | albums    |
| xml    | albums    |