# Order Models
### Could be a low-level abstract model, made specific with two more order models for shipping orders and pickup orders
## Abstract Order Model
* Order ID (Primary Key)
* Products being ordered (Line Items) (Foreign Key?)
* Customer ID (Foreign Key)
* DBONLY: Shipped order or live pickup?
* Order Placement time
* Store Location
* Subtotal
* ????

## Shipping Order Model
* Origin Address (This is the Store Location)
* Order Shipment Date
* Destination Address
* Time until shipped?

## Pickup Order Model
* Store Location
* Pickup date