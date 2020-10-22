# P0 Requirements:

Due Wednesday of Week 3 (November 4)

## Store App

### Overview:

The store app is a software that helps customers purchase products from your business. Designed with functionality that would make virtual shopping much simpler!
 
## Functionality:
* The customer should be able to place orders
* The customer should be able to view their order history
* The customer should be able to view location inventory
* The customer should know how much of a product is remaining
* The customer should be able to purchase multiple products
* Locations should have records of order history
* Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
* The manager should be able to replenish inventory
* 3 Locations, multiple products

 
## Models: 
// Should probably be done by the first Saturday night
* Customer
* Location
* Orders
* Product
* Note: add as much models as you would need for your design

 
## Additional requirements:
* Exception Handling
* Input validation
* Logging
* At least 10 unit tests // focus on testing data access and services (Business Logic)
* Data should be persistent, (no data should be hard coded)
    * Look into serializing your data and storing them on files
* Code should have xml documentation

 
## Tech Stack:
* C#
* Xunit
* Serilog or Nlog (or other logging frameworks)
