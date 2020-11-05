using Microsoft.EntityFrameworkCore.Migrations;

namespace IceShopDB.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -3,
                column: "placedtime_posix",
                value: 1602226800.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -2,
                column: "placedtime_posix",
                value: 1602658800.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1,
                column: "placedtime_posix",
                value: 1602313200.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -3,
                column: "placedtime_posix",
                value: 1602572400.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -2,
                column: "placedtime_posix",
                value: 1603954800.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1,
                column: "placedtime_posix",
                value: 1603522800.0);
        }
    }
}
