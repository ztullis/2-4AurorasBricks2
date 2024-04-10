﻿
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2_4AurorasBricks2.Models;

public partial class LegoContext : DbContext
{
    public LegoContext()
    {
    }

    public LegoContext(DbContextOptions<LegoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<LineItem> LineItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:myfreesqldbservertullisintex2.database.windows.net,1433;Initial Catalog=TullisINTEXDB2;Persist Security Info=False;User ID=group2-4;Password=zjro2-4intex;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__mytable__CD64CFDD34B348AC");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_ID");
            entity.Property(e => e.Age)
                .HasColumnType("numeric(4, 1)")
                .HasColumnName("age");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CountryOfResidence)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("country_of_residence");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<LineItem>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ProductId).HasColumnName("product_ID");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_ID");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Bank)
                .HasMaxLength(50)
                .HasColumnName("bank");
            entity.Property(e => e.CountryOfTransaction)
                .HasMaxLength(50)
                .HasColumnName("country_of_transaction");
            entity.Property(e => e.CustomerId).HasColumnName("customer_ID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EntryMode)
                .HasMaxLength(50)
                .HasColumnName("entry_mode");
            entity.Property(e => e.Fraud).HasColumnName("fraud");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(50)
                .HasColumnName("shipping_address");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_ID");
            entity.Property(e => e.TypeOfCard)
                .HasMaxLength(50)
                .HasColumnName("type_of_card");
            entity.Property(e => e.TypeOfTransaction)
                .HasMaxLength(50)
                .HasColumnName("type_of_transaction");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__mytable__470175FD2B797A6B");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_ID");
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(2752)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImgLink)
                .HasMaxLength(136)
                .IsUnicode(false)
                .HasColumnName("img_link");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NumParts).HasColumnName("num_parts");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PrimaryColor)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("primary_color");
            entity.Property(e => e.SecondaryColor)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("secondary_color");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}