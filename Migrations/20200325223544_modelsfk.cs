using Microsoft.EntityFrameworkCore.Migrations;

namespace RPM_Tool.Migrations
{
    public partial class modelsfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Utility_Utilities_UtilityId",
                table: "Building_Utility");

            migrationBuilder.DropForeignKey(
                name: "FK_Building_Vendor_Vendors_VendorId",
                table: "Building_Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45e39e7f-3e26-4630-8330-b2f6d88ce199");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71905dfa-3691-4494-aead-091df899dbaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcd43206-53fd-4fb4-b161-4ce16c71db4f");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Utilities");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Vendors",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UtilityId",
                table: "Utilities",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "VendorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities",
                column: "UtilityId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c5e9b0c-2f39-4ea6-b527-e158eba76faa", "bb995bf5-fc63-44ab-8ca9-9980461bc372", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b558912-0bab-4cbb-a345-429a9e7a4e12", "e6d3032a-1471-4131-8d4f-f2fd43315cd2", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6567d56b-7795-48eb-ba66-7ae1d3e3e94a", "cec21360-4c5d-4be2-919e-440e29e546d4", "Tenant", "TENANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Utility_Utilities_UtilityId",
                table: "Building_Utility",
                column: "UtilityId",
                principalTable: "Utilities",
                principalColumn: "UtilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Vendor_Vendors_VendorId",
                table: "Building_Vendor",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Utility_Utilities_UtilityId",
                table: "Building_Utility");

            migrationBuilder.DropForeignKey(
                name: "FK_Building_Vendor_Vendors_VendorId",
                table: "Building_Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b558912-0bab-4cbb-a345-429a9e7a4e12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6567d56b-7795-48eb-ba66-7ae1d3e3e94a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c5e9b0c-2f39-4ea6-b527-e158eba76faa");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "UtilityId",
                table: "Utilities");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Utilities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcd43206-53fd-4fb4-b161-4ce16c71db4f", "aaf3626f-0e7b-46ea-a4dc-4c9424e6783e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45e39e7f-3e26-4630-8330-b2f6d88ce199", "6bfb6283-f3e6-45b9-bc6a-094a5975b554", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71905dfa-3691-4494-aead-091df899dbaf", "95c5410d-5696-42cd-99d0-12e3c2f5b4b0", "Tenant", "TENANT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Utility_Utilities_UtilityId",
                table: "Building_Utility",
                column: "UtilityId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Vendor_Vendors_VendorId",
                table: "Building_Vendor",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
