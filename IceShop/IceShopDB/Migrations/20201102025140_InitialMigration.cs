using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IceShopDB.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    Subtotal = table.Column<double>(nullable: false),
                    placedtime_posix = table.Column<double>(nullable: false),
                    finishedtime_posix = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLineItems",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLineItems", x => new { x.LocationId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InventoryLineItems_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLineItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    product_quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderLineItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLineItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "password" },
                values: new object[,]
                {
                    { -1, "Nick's house", "nevanwest@west.com", "Nick West", "nevaniscool" },
                    { -2, "Vin's house", "vincent.weis@revature.com", "Vincent Wees", "password" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { -1, "Earth's core, presumably.", "Hell" },
                    { -2, "In a laundry hamper", "Dirty Sock" },
                    { -3, "1 E Washington St., #230, Phoenix, AZ 85004", "Phoenix" }
                });

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
                table: "Managers",
                columns: new[] { "Id", "Email", "LocationId", "Name", "password" },
                values: new object[,]
                {
                    { -11, "reallycool@email.com", -1, "Tubular Tom", "IJustLikeTubes1" },
                    { -12, "sample@manager.com", -2, "Vincent Weis", "bestmanager" },
                    { -13, "spiderthing@lake.net", -3, "Vacuous Rom", "IAmASpider3" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CustomerId", "LocationId", "Subtotal", "finishedtime_posix", "placedtime_posix" },
                values: new object[,]
                {
                    { -1, "Nick's house", -1, -1, 23.0, 0.0, 1602572400.0 },
                    { -2, "Vin's house", -2, -2, 18.0, 0.0, 1603609200.0 },
                    { -3, "Nick's house", -1, -2, 7.0, 0.0, 1602313200.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderLineItems",
                columns: new[] { "OrderId", "ProductId", "product_quantity" },
                values: new object[,]
                {
                    { -1, 1, 1 },
                    { -1, 2, 2 },
                    { -2, 3, 3 },
                    { -2, 2, 1 },
                    { -3, 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLineItems_ProductId",
                table: "InventoryLineItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_LocationId",
                table: "Managers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItems_ProductId",
                table: "OrderLineItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryLineItems");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "OrderLineItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
