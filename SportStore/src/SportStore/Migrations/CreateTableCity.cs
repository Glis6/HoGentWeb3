using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportStore.Migrations
{
    public partial class CreateTableCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "City",
                table => new
                {
                    Postalcode = table.Column<string>(maxLength: 450),
                    Name = table.Column<string>(maxLength: 100)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Postalcode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "City");
        }
    }
}
