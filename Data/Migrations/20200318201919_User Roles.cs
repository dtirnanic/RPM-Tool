using Microsoft.EntityFrameworkCore.Migrations;

namespace RPM_Tool.Data.Migrations
{
    public partial class UserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72d14eaa-4ac6-4cb9-9975-9b25484b1802");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "871652d1-0f1d-429a-9083-16750d7bfff4", "49c845f0-8972-49e2-80bd-5c3ae8c6ca0a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37c2eecb-66bc-41e5-8f55-21cbf0aa40d9", "3805efa3-657a-4c2d-b783-be2939f4b613", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a7b4d98-12a7-4f61-b1d7-508431bdbb51", "f1d8987a-d62d-45fd-9ee9-9f2fcce61571", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a7b4d98-12a7-4f61-b1d7-508431bdbb51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c2eecb-66bc-41e5-8f55-21cbf0aa40d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "871652d1-0f1d-429a-9083-16750d7bfff4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72d14eaa-4ac6-4cb9-9975-9b25484b1802", "e1d45272-7cbb-432e-8c46-24be06ec2e01", "Admin", "ADMIN" });
        }
    }
}
