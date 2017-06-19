# CheckoutTest
test for checkout.com


The assignment consists of two projects.

.net core web api to handle crud and data storage of office drinks shoppings

 .net library adapted from https://github.com/CKOTech/checkout-net-library. which interacts with the running service. 

main classes to see

**webapi**  

 1. DrinkService.cs
 2. Startup.cs
 3. CheckoutContext.cs
 4. DrinkController.cs
 5. AuthMiddleware.cs

**Modified sdk**

 1. all files within checkout-net-library\Checkout.ApiClient.Net45\ApiServices\Office\*
 2. C:\Projects\CheckoutTest\checkout-net-library\Checkout.ApiClient.Tests\OfficeService\OfficeServicetests.cs

**Tests**

The tests for the project reside in the modified sdk project at the location above to illustrate how they would integrate with the existing test pack. My preference is to test to the underlying services within the webApi but for the scope of this assignment I felt they only need to be in one place.  My view is test the logic within the service and integration tests for the consuming libraries that check if the returned data is allowable rather then correct. Since this was a crud exercise there wasn't really room for that

**choices and assumptions**

 - It wasn't within the scope of the assignment to action a delivery
 - ms localdb is acceptable in replacement for a in memory solution. I find it just as quick and easy to set up and its doesn't require a sql server install, its stored in a portable binary within the project. It allowed me to demonstrate use of ORM and db schema. Although the scope of the assigment maybe didn't need it
 - I have implemented auth on the endpoint but just as an example useing the bundled secret framework you have built in the httpClient within the sdk library. hardcoding a string match. Would in implementation make it basic auth or idealy run an identity server instance.
 - If you have any questions of issues running the assignment please feel free to contact me
 