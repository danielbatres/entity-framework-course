using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_project.Migrations
{
    public partial class ColumnWeigthCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weigth",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weigth",
                table: "Category");
        }
    }
}
