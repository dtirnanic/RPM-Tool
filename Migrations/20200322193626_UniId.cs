using Microsoft.EntityFrameworkCore.Migrations;

namespace RPM_Tool.Migrations
{
    public partial class UniId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e608ac-3614-4443-a392-a6449ebdc30b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "459e23ae-93a7-4012-b6b6-0013cbe9708a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc92778-6de4-45e5-81fc-8d4b6500d1fe");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Tenants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85acd9e3-5375-469a-9fdd-498422777029", "62b8dd79-daa7-4980-8450-6b2342dd1146", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24d0be16-ed61-4892-8644-ab9889e70d8b", "32a1f2fb-6e4d-4312-9429-71b0fe5894bc", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "299effdb-e380-4198-b71b-fe6f923d995b", "4568d802-9d77-4f3a-88e9-07ed64c77d22", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24d0be16-ed61-4892-8644-ab9889e70d8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "299effdb-e380-4198-b71b-fe6f923d995b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85acd9e3-5375-469a-9fdd-498422777029");

            migrationBuilder.AlterColumn<string>(
                name: "UnitId",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "459e23ae-93a7-4012-b6b6-0013cbe9708a", "01bc4cd4-8486-412e-98d5-17172eb3610d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dc92778-6de4-45e5-81fc-8d4b6500d1fe", "a40fbdbd-81c6-4128-9c19-29704cacc71d", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00e608ac-3614-4443-a392-a6449ebdc30b", "fff652b9-a798-44bf-8a78-c606aacd1c88", "Tenant", "TENANT" });
        }
    }
}
