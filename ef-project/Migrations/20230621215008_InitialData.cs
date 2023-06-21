using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_project.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weigth",
                table: "Category",
                newName: "Weight");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("824d3c0a-900f-4069-a80f-ade59940e020"), null, "Pending activities", 20 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("824d3c0a-900f-4069-a80f-ade59940e022"), null, "Personal activities", 50 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDateTime", "Description", "TaskPriority", "Title" },
                values: new object[] { new Guid("0bf7dc7e-930c-45b4-b957-d9b6e9f5a175"), new Guid("824d3c0a-900f-4069-a80f-ade59940e022"), new DateTime(2023, 6, 21, 15, 50, 8, 605, DateTimeKind.Local).AddTicks(8355), null, 0, "Finish watching movie on netflix" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDateTime", "Description", "TaskPriority", "Title" },
                values: new object[] { new Guid("4da3fc64-ee46-4654-9387-f2ea2fe4116b"), new Guid("824d3c0a-900f-4069-a80f-ade59940e020"), new DateTime(2023, 6, 21, 15, 50, 8, 605, DateTimeKind.Local).AddTicks(8302), null, 1, "Payment of public services" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("0bf7dc7e-930c-45b4-b957-d9b6e9f5a175"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4da3fc64-ee46-4654-9387-f2ea2fe4116b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("824d3c0a-900f-4069-a80f-ade59940e020"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("824d3c0a-900f-4069-a80f-ade59940e022"));

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Category",
                newName: "Weigth");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
