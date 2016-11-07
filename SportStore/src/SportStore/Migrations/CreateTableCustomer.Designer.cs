using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportStore.Data;

namespace SportStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161107154418_CreateTableCustomer")]
    partial class CreateTableCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsStore.Models.City", b =>
                {
                    b.Property<string>("Postalcode");

                    b.Property<string>("Name");

                    b.HasKey("Postalcode");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SportsStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityPostalcode");

                    b.Property<string>("CustomerName");

                    b.Property<string>("FirstName");

                    b.Property<string>("Name");

                    b.Property<string>("Street");

                    b.HasKey("CustomerId");

                    b.HasIndex("CityPostalcode");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SportsStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SportsStore.Models.Customer", b =>
                {
                    b.HasOne("SportsStore.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityPostalcode");
                });
        }
    }
}
