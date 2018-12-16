# justeat
Just Eat Automation Test

## Running Requirements

### Software
* Visual Studio 2017
* .NET Framework 4.6.1
* ReSharper (latest)

### Plugins & Assembiles
Specflow [plugin](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017)

System.Configuration reference added in the project from References management in Visual Studio

### Nuget Packages
* NUnit version="3.0.0"
* Selenium.Support version="3.141.0"
* Selenium.WebDriver version="3.141.0" 
* Selenium.WebDriver.ChromeDriver
* SpecFlow version="2.4.0"
* SpecFlow.NUnit version="2.4.0" 
* System.ValueTuple version="4.3.0"
* Newtonsoft.Json version="10.0.3"

## Running Steps
* After installing advised software, clone the repro from github
* Open the .sln file
* Restore/Install all mentioned Nuget packages in Visual Studio
* Add the System.Configuration reference in the project from References management in Visual Studio
* Ensure you have installed Selenium.WebDriver.ChromeDriver Nuget package by author jsakamoto
* Build solution
* Using Resharper Unit Tests option, run the tests

## Additional Comments
1) Test "Search for restaurants in an area" searches for a given postcode in specflow test data and checks that at least 1 restaurant is found.

2) Test "Sign up a restaurant" uses the sign up restaurant form from the home page footer to register a restaurant. The caveat with this test is that a particular sign up wizard stopped appearing the next day from when the test was written. This looks like a user based experience behaviour of the site which I have no control of. Therefore I had to update this test by introducing more page objects and adding further step options to cater for the wizard, but I had preferred to spend time in updating my explicit thread.sleep waits to implicit waits on this test.

3) Test "Can login to the system successfully" is a straightforward test to let a registered user login. I have registered a dummy user using a mailinator account at the time of writing this test.
