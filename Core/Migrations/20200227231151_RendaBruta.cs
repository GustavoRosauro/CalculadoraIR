using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class RendaBruta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RendeBruta",
                table: "Contribuintes");

            migrationBuilder.AddColumn<double>(
                name: "RendaBruta",
                table: "Contribuintes",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RendaBruta",
                table: "Contribuintes");

            migrationBuilder.AddColumn<double>(
                name: "RendeBruta",
                table: "Contribuintes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
