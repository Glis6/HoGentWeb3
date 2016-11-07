using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportStore.Data;

namespace SportStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161107155449_CreateTableOrder")]
    partial class CreateTableOrder
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

            modelBuilder.Entity("SportsStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime?>("DeliveryDate");

                    b.Property<bool>("Giftwrapping");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("ShippingCityPostalcode");

                    b.Property<string>("ShippingStreet");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShippingCityPostalcode");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SportsStore.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
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

            modelBuilder.Entity("SportsStore.Models.Order", b =>
                {
                    b.HasOne("SportsStore.Models.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("SportsStore.Models.City", "ShippingCity")
                        .WithMany()
                        .HasForeignKey("ShippingCityPostalcode");
                });

            modelBuilder.Entity("SportsStore.Models.OrderLine", b =>
                {
                    b.HasOne("SportsStore.Models.Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
