using Microsoft.EntityFrameworkCore.Migrations;

namespace RPM_Tool.Migrations
{
    public partial class TwilioAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TwilioAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthToken = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwilioAccounts", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwilioAccounts");

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
    }
}
