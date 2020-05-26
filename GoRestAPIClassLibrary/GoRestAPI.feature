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

@negative
Scenario Outline: Validate API response for Bad Request
	Given user has an endpoint
	When get request with <format> header format is sent to endpoint <endpoint>
	Then api response is with not ok status	
Examples:
| format | endpoint |
| json   | user		|
| xml    | user	    |
| json   | album    |
| xml    | album    |