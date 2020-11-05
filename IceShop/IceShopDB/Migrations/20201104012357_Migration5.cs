using Microsoft.EntityFrameworkCore.Migrations;

namespace IceShopDB.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -3, 1 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -2, 2 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -2, 3 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -1, 1 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -3, 2 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -2, 3 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -1, 2 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { -1, "The sensation of being on fire, usually caused by being on fire.", "Burning", 20.0, 0 },
                    { -2, "They're really cute, actually, if your brain is messed up.", "Sad Puppy Picture", 8.0, 2 },
                    { -3, "Become Spiders-Man, and become a hive mind of spiders.", "Spider Infestation", 12.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "InventoryLineItems",
                columns: new[] { "LocationId", "ProductId", "ProductQuantity" },
                values: new object[,]
                {
                    { -1, -1, 5 },
                    { -3, -1, 12 },
                    { -2, -2, 3 },
                    { -1, -3, 2 },
                    { -2, -3, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderLineItems",
                columns: new[] { "OrderId", "ProductId", "product_quantity" },
                values: new object[,]
                {
                    { -1, -1, 1 },
                    { -1, -2, 2 },
                    { -2, -2, 1 },
                    { -3, -2, 6 },
                    { -2, -3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -3, -1 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -2, -3 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "InventoryLineItems",
                keyColumns: new[] { "LocationId", "ProductId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -3, -2 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -2, -3 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "OrderLineItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "The sensation of being on fire, usually caused by being on fire.", "Burning", 20.0, 0 },
                    { 2, "They're really cute, actually, if your brain is messed up.", "Sad Puppy Picture", 8.0, 2 },
                    { 3, "Become Spiders-Man, and become a hive mind of spiders.", "Spider Infestation", 12.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "InventoryLineItems",
                columns: new[] { "LocationId", "ProductId", "ProductQuantity" },
                values: new object[,]
                {
                    { -1, 1, 5 },
                    { -3, 1, 12 },
                    { -2, 2, 3 },
                    { -1, 3, 2 },
                    { -2, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderLineItems",
                columns: new[] { "OrderId", "ProductId", "product_quantity" },
                values: new object[,]
                {
                    { -1, 1, 1 },
                    { -1, 2, 2 },
                    { -2, 2, 1 },
                    { -3, 2, 6 },
                    { -2, 3, 3 }
                });
        }
    }
}
