using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2_4AurorasBricks2.Migrations.Lego
{
    /// <inheritdoc />
    public partial class second3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rec_1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rec_2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rec_3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rec_4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rec_5",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rec_1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rec_2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rec_3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rec_4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rec_5",
                table: "Products");
        }
    }
}
