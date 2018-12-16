# justeat
Just Eat Automation Test

#Running Requirements

##Software
1) Visual Studio 2017
2).NET Framework 4.6.1
3) ReSharper (latest)

##Plugins & Assembiles
Specflow [plugin] https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017
System.Configuration reference added in the project from References management in Visual Studio

##Nuget Packages
NUnit version="3.0.0"
Selenium.Support version="3.141.0"
Selenium.WebDriver version="3.141.0" 
Selenium.WebDriver.ChromeDriver
SpecFlow version="2.4.0"
SpecFlow.NUnit version="2.4.0" 
System.ValueTuple version="4.3.0"
Newtonsoft.Json version="10.0.3"

#Additional Comments
1) Test "Search for restaurants in an area" searches for a given postcode in specflow test data and checks that at least 1 restaurant is found.

2) Test "Sign up a restaurant" uses the sign up restaurant form from the home page footer to register a restaurant. The problem with this test is that a particular
sign up wizard stopped appearing the next day from when the tests were written. This looks like a random user based behaviour of the site which I have no control of. 
Due to the shortage of time and that test was already completed and working before this problem occurred, I was unable to spend time in maintaining this issue. Conceptually
I would deal with this problem using an if statement to check for wizard and perform actions accordingly. 
Sometimes the wizard does appear and this then makes this test run and pass however.

3) Test "Cannot login to the system as an unknown user" is a straightforward test to not let a malicious user login. I opted for this negative case as appose to standard successful login
test due to not having an already registered user at hand.

