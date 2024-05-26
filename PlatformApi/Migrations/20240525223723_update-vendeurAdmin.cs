using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformApi.Migrations
{
    public partial class updatevendeurAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "VendeurAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "VendeurAdmin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "VendeurAdmin");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "VendeurAdmin");
        }
    }
}
