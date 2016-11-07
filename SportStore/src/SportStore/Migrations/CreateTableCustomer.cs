using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportStore.Migrations
{
    public partial class CreateTableCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Customer",
                table => new
                {
                    CustomerId = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityPostalcode = table.Column<string>(maxLength: 450),
                    CustomerName = table.Column<string>(maxLength: 20),
                    FirstName = table.Column<string>(maxLength: 100),
                    Name = table.Column<string>(maxLength: 100),
                    Street = table.Column<string>(maxLength: 100)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        "FK_Customer_City_CityPostalcode",
                        x => x.CityPostalcode,
                        "City",
                        "Postalcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Customer_CityPostalcode",
                "Customer",
                "CityPostalcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Customer");
        }
    }
}
