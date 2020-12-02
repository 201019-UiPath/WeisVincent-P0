# Store Application

This application is designed with functionality that would make virtual shopping much simpler! Customers can sign up for an account, place orders, view their order history, and specific location inventory. It also comes with an additional interface for managing your business. Managers can view and replenish location inventory, add new products, and view the order history of specific locations. This application used Entity Framework Core to connect to a PostgreSQL database, and .NET Framework Core to make a console-based interface. 

## Functionality

### User-Agnostic functionality
- The shop sells various forms of ice as products.
    - Each Product has a name, a price, an enumerated type/category, and a description in the database.
- Each user can sign up with their name, email, and password, and then login with their email and password.
    - All user input of any form is validated with a custom validation class library that can operate with any Regex input condition or list of conditions passed to the validator, as long as the condition class implements the IInputCondition interface.
- All order histories of any kind can be sorted by date and price, in ascending or descending order.
- The menu system is modularized with a pseudo-factory class that handles menu progression, allowing the disposal of previous menus.

### Customer Functionality
- The Customer is greeted by name and offered the choice to view their own order history, select a location to order from, or exit the program.
    - Subsequent menus allow the customer to return to this start menu unless they’re in a contextual submenu or finalizing an order.
- Customer order histories include:
    - The location of the order
    - Subtotal of the order
    - A list of products bought in each order, complete with quantity of each product.
- Customers can view the stock of each product at each location, type the quantity of the product they want, and build up their cart before submitting their order.

### Manager Functionality
- The Manager is greeted with a reminder of their assigned location, and offered the choice to view their location’s order history, manage order history, or exit the program.
    - Subsequent menus allow the manager to return to this start menu unless they’re in a contextual submenu.
- Location order histories include any order placed at that location, with the same sorting capability and formatting as Customer histories.
- Managers have a lot of flexibility in managing stock. They are able to:
    - Increase or decrease the stock of existing items in stock
    - Add an existing product that isn’t in stock to their location
    - Add a brand new product that hasn’t existed before to the SufferShop Catalogue.

### Other Program Notes
- Comprehensive input validation unit tests
- Program Business Logic and Library are separated so the validation and custom exception logic can be slotted into other applications.
- There is currently no way to add a new Location, by design. Such a massive event didn’t seem like something that one would want to include in an end-user application, even with manager-functions. But the model and constructors are configured so that functionality could be added swiftly if needed.

## Prerequisites

- .NET Framework Core 3.1 and above

## License

This project is licensed under the MIT License.
