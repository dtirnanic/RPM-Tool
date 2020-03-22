using Microsoft.EntityFrameworkCore.Migrations;

namespace RPM_Tool.Migrations
{
    public partial class TwilioAccountsFromNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "271b8ab2-cc98-4c9d-b9fe-962b6268e5a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39fcbb20-2d30-4fdc-858f-00d38afe4a12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e872ecd-076f-4e07-8c6a-a1bcccaefb86");

            migrationBuilder.AddColumn<string>(
                name: "FromNumber",
                table: "TwilioAccounts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc5655fa-449d-4123-87ea-8dd0a0971814", "bd486be1-6cdc-4160-8055-26417ed73f8e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1a7ef11-6a9a-4279-8f3e-629b97af9d61", "ae2a4dbf-fcfd-46be-92a0-ada64107135b", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e21d5a22-0940-41d8-ba9f-f9c4d64b0c8d", "3553ce81-6a86-4589-9b51-c7ea7f4016f3", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a7ef11-6a9a-4279-8f3e-629b97af9d61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e21d5a22-0940-41d8-ba9f-f9c4d64b0c8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc5655fa-449d-4123-87ea-8dd0a0971814");

            migrationBuilder.DropColumn(
                name: "FromNumber",
                table: "TwilioAccounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e872ecd-076f-4e07-8c6a-a1bcccaefb86", "d49e438e-0112-4a86-a6e3-f8b56f993b0e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "271b8ab2-cc98-4c9d-b9fe-962b6268e5a0", "7e43ef01-75ae-4df2-8027-48354e75097a", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39fcbb20-2d30-4fdc-858f-00d38afe4a12", "24244762-280f-4c4c-a852-f0f7e204e6c9", "Tenant", "TENANT" });
        }
    }
}
