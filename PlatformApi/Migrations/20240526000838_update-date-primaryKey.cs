using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformApi.Migrations
{
    public partial class updatedateprimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VendeurAdmin",
                table: "VendeurAdmin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendeurAdmin",
                table: "VendeurAdmin",
                columns: new[] { "VendeurId", "AdminId", "ModifiedAt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VendeurAdmin",
                table: "VendeurAdmin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendeurAdmin",
                table: "VendeurAdmin",
                columns: new[] { "VendeurId", "AdminId" });
        }
    }
}
