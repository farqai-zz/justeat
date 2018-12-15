Feature: Use the website to find restaurants
  So that I can order food
  As a hungry customer
  I want to be able to find restaurants in my area

Scenario: Search for restaurants in an area
  Given I want food in "AR51 1AA"
  When I search for restaurants
  Then I should see some restaurants in AR51 1AA

  
Scenario Outline: Sign up a restaurant
Given I want to sign up to a restaurant
When I provide my '<firstname>' and '<lastname>' and '<mobile>' and '<email>' and '<restaurant>' and '<street>' and '<city>' and '<postcode>' and '<cuisine>' and '<status>' and '<drivers>'
Then I have successfully registered my restaurant
Examples: 
| firstname | lastname | mobile      | email           | restaurant | street  | city  | postcode | cuisine | status     | drivers |
| test      | user     | 00000000000 | test@testme.com | mbison     | fighter | osaka | sm1 3de  | indian  | collection | 10      |

Scenario Outline: Login to the system as an existing user
Given I want to login
When I provide my <email> and <password>
Then I have logged in successfully 
Examples: 
| email           | password  |
| test@testme.com | test123!A |