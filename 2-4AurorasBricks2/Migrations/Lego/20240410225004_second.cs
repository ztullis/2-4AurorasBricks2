using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2_4AurorasBricks2.Migrations.Lego
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "secondary_color",
                table: "Products",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "primary_color",
                table: "Products",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "num_parts",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Products",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "img_link",
                table: "Products",
                type: "varchar(136)",
                unicode: false,
                maxLength: 136,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 136);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "varchar(2752)",
                unicode: false,
                maxLength: 2752,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 2752);

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Products",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "product_ID",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "type_of_transaction",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "type_of_card",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "transaction_ID",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "time",
                table: "Orders",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shipping_address",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fraud",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "entry_mode",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "day_of_week",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date",
                table: "Orders",
                type: "date",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customer_ID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country_of_transaction",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bank",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "amount",
                table: "Orders",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "transaction_ID",
                table: "LineItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "rating",
                table: "LineItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "qty",
                table: "LineItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "product_ID",
                table: "LineItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "Customers",
                type: "varchar(21)",
                unicode: false,
                maxLength: 21,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 21,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Customers",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "Customers",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "country_of_residence",
                table: "Customers",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "birth_date",
                table: "Customers",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "customer_ID",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "secondary_color",
                table: "Products",
                type: "TEXT",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "primary_color",
                table: "Products",
                type: "TEXT",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "num_parts",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Products",
                type: "TEXT",
                unicode: false,
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldUnicode: false,
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "img_link",
                table: "Products",
                type: "TEXT",
                unicode: false,
                maxLength: 136,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(136)",
                oldUnicode: false,
                oldMaxLength: 136);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "TEXT",
                unicode: false,
                maxLength: 2752,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2752)",
                oldUnicode: false,
                oldMaxLength: 2752);

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Products",
                type: "TEXT",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "product_ID",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "type_of_transaction",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "type_of_card",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "transaction_ID",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "time",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shipping_address",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fraud",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "entry_mode",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "day_of_week",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customer_ID",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country_of_transaction",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bank",
                table: "Orders",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "amount",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "transaction_ID",
                table: "LineItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "rating",
                table: "LineItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "qty",
                table: "LineItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "product_ID",
                table: "LineItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "Customers",
                type: "TEXT",
                unicode: false,
                maxLength: 21,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(21)",
                oldUnicode: false,
                oldMaxLength: 21,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Customers",
                type: "TEXT",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "Customers",
                type: "TEXT",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "country_of_residence",
                table: "Customers",
                type: "TEXT",
                unicode: false,
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false,
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "birth_date",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "customer_ID",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
