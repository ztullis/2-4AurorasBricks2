﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2_4AurorasBricks2.Models;

#nullable disable

namespace _2_4AurorasBricks2.Migrations.Lego
{
    [DbContext(typeof(LegoContext))]
    [Migration("20240411174150_second3")]
    partial class second3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2_4AurorasBricks2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_ID");

                    b.Property<decimal>("Age")
                        .HasColumnType("numeric(4, 1)")
                        .HasColumnName("age");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("CountryOfResidence")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("country_of_residence");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .HasMaxLength(21)
                        .IsUnicode(false)
                        .HasColumnType("varchar(21)")
                        .HasColumnName("last_name");

                    b.HasKey("CustomerId")
                        .HasName("PK__mytable__CD64CFDD34B348AC");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("_2_4AurorasBricks2.Models.LineItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_ID");

                    b.Property<int>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int")
                        .HasColumnName("transaction_ID");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("_2_4AurorasBricks2.Models.Order", b =>
                {
                    b.Property<short?>("Amount")
                        .HasColumnType("smallint")
                        .HasColumnName("amount");

                    b.Property<string>("Bank")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("bank");

                    b.Property<string>("CountryOfTransaction")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("country_of_transaction");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_ID");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<string>("DayOfWeek")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("day_of_week");

                    b.Property<string>("EntryMode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("entry_mode");

                    b.Property<int?>("Fraud")
                        .HasColumnType("int")
                        .HasColumnName("fraud");

                    b.Property<string>("ShippingAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("shipping_address");

                    b.Property<byte?>("Time")
                        .HasColumnType("tinyint")
                        .HasColumnName("time");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int")
                        .HasColumnName("transaction_ID");

                    b.Property<string>("TypeOfCard")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("type_of_card");

                    b.Property<string>("TypeOfTransaction")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("type_of_transaction");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_2_4AurorasBricks2.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_ID");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2752)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2752)")
                        .HasColumnName("description");

                    b.Property<string>("ImgLink")
                        .IsRequired()
                        .HasMaxLength(136)
                        .IsUnicode(false)
                        .HasColumnType("varchar(136)")
                        .HasColumnName("img_link");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("name");

                    b.Property<int>("NumParts")
                        .HasColumnType("int")
                        .HasColumnName("num_parts");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("PrimaryColor")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("primary_color");

                    b.Property<string>("Rec_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rec_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rec_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rec_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rec_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryColor")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("secondary_color");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("ProductId")
                        .HasName("PK__mytable__470175FD2B797A6B");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}