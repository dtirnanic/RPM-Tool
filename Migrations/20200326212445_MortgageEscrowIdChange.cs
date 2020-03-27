using Microsoft.EntityFrameworkCore.Migrations;

namespace RPM_Tool.Migrations
{
    public partial class MortgageEscrowIdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageAndEscrows",
                table: "MortgageAndEscrows");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c1f50fa-fcf3-4ebb-a43a-2fc635ba6d22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfe2590b-ae44-4994-a114-4871fea10f4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53c50c1-2e88-409b-9e16-45432da05daa");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MortgageAndEscrows");

            migrationBuilder.AddColumn<int>(
                name: "MortgageAndEscrowId",
                table: "MortgageAndEscrows",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageAndEscrows",
                table: "MortgageAndEscrows",
                column: "MortgageAndEscrowId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4a4abf8-8326-4688-8c07-2c4af54dce51", "4d1302c8-9799-47fe-b613-1e103631cfa3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fda4e9f-fadc-464a-a750-1b90a7824b76", "6f58f92f-9b97-4817-8dd1-df6a6d0d7b49", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bda92dc2-aaff-4fc4-93ac-84cc78205fed", "fa1af70f-fd06-46f9-a275-555a9519540b", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageAndEscrows",
                table: "MortgageAndEscrows");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fda4e9f-fadc-464a-a750-1b90a7824b76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda92dc2-aaff-4fc4-93ac-84cc78205fed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4a4abf8-8326-4688-8c07-2c4af54dce51");

            migrationBuilder.DropColumn(
                name: "MortgageAndEscrowId",
                table: "MortgageAndEscrows");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MortgageAndEscrows",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageAndEscrows",
                table: "MortgageAndEscrows",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfe2590b-ae44-4994-a114-4871fea10f4e", "11176fd8-9d64-4ce9-9b2b-6615540f5564", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d53c50c1-2e88-409b-9e16-45432da05daa", "d7bf05b3-a6eb-41f0-9a77-a0be2b51b429", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c1f50fa-fcf3-4ebb-a43a-2fc635ba6d22", "35ed0872-e879-4fb1-8f05-3f35ac9f2fd2", "Tenant", "TENANT" });
        }
    }
}
