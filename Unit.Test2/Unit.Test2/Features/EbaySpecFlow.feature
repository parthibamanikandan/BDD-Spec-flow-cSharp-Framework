Feature: As a guest user to ebay
I am able to add two items to cart
And go to checkout

@mytag
Scenario: Add two items to the cart and goto checkout
	Given user launches ebay website
	When user searches "iPhone" and select first item
	And user selects "iPhone" preferences and add to cart
	And user searches "iPhone case" and select first item
	And user selects "iPhone case" preferences and add to cart
	#And User press Go to Checkout
	Then user should have 2 items in the cart
