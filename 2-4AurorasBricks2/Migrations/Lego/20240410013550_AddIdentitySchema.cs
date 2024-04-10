using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2_4AurorasBricks2.Migrations.Lego
{
    /// <inheritdoc />
    public partial class AddIdentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 21, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    country_of_residence = table.Column<string>(type: "TEXT", unicode: false, maxLength: 14, nullable: false),
                    gender = table.Column<string>(type: "TEXT", unicode: false, maxLength: 1, nullable: true),
                    age = table.Column<decimal>(type: "numeric(4, 1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mytable__CD64CFDD34B348AC", x => x.customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    transaction_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    product_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    qty = table.Column<int>(type: "INTEGER", nullable: false),
                    rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    transaction_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    customer_ID = table.Column<int>(type: "INTEGER", nullable: true),
                    date = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    day_of_week = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    time = table.Column<byte>(type: "INTEGER", nullable: true),
                    entry_mode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    amount = table.Column<short>(type: "INTEGER", nullable: true),
                    type_of_transaction = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    country_of_transaction = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    shipping_address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    bank = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    type_of_card = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    fraud = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 60, nullable: false),
                    year = table.Column<int>(type: "INTEGER", nullable: false),
                    num_parts = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false),
                    img_link = table.Column<string>(type: "TEXT", unicode: false, maxLength: 136, nullable: false),
                    primary_color = table.Column<string>(type: "TEXT", unicode: false, maxLength: 6, nullable: false),
                    secondary_color = table.Column<string>(type: "TEXT", unicode: false, maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "TEXT", unicode: false, maxLength: 2752, nullable: false),
                    category = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mytable__470175FD2B797A6B", x => x.product_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
