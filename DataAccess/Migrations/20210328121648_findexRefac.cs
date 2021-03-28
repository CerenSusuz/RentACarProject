using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class findexRefac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FindexScore",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "FindexScore",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinFindexScore",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FindexScore",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MinFindexScore",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "FindexScore",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
