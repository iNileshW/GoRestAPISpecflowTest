# GoRestAPISpecflowTest

Prerequisite: 
Create an account in https://gorest.co.in/ website to get the access token and perform the following test cases. 
We do not own this website or the endpoint but for this task this free endpoints is sufficient. There is a limitation – it supports 60 requests per account only. Hope the following test cases do not cross this limit but if it crosses then you need to create another free account. 
This endpoints support json and xml data format. To perform json, add _format=json and to perform xml, add _format=xml in the query parameter.  We would like to cover both data format in all of the test cases.

Test Case 1: Perform Get All User operation on the following URL. 
URL: https://gorest.co.in/public-api/users?_format=jsonOrXmlDataFormat_goes_here&access-token=token goes_here
Expected Result:
•	Http status code: 200
•	Total count of the record more than 1 in meta.

Pick random user_id from the result. This value will be used in other test cases

Test Case 2: Perform Get Albums by user id.
URL: https://gorest.co.in/public-api/albums?user_id=userId_goeshere&_format= jsonOrXmlDataFormat_goes_here&access-token=token goes_here
Expected Result:
•	Http status code: 200
•	Total count of the record more than 1 in meta.
•	Verify user id in the response is same as requested in the url

Test Case 3: 
Pick any of the resource (Users, Albums, etc.,) and come up with one negative test case and implement in the code.
Task:
Produce Visual Studio solution that tests the above 3 test cases using NUnit, Specflow, BDD and .NET Core 3.0.
Note: It will great if you could demonstrate how you can reuse the C# code, Tag, Share data between feature files and scenarios wherever possible. 
Once you are done push the code to git and share the url or zip the solution and share it with us.
All the best
