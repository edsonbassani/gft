using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Roa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DishTypeId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_DishType_DishTypeId",
                        column: x => x.DishTypeId,
                        principalTable: "DishType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dish_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DishType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Entree" },
                    { 2, "Side" },
                    { 3, "Drink" },
                    { 4, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Period",
                columns: new[] { "Id", "EndTime", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 11, 59, 59, 0), "Morning", new TimeSpan(0, 6, 0, 0, 0) },
                    { 2, new TimeSpan(0, 23, 59, 59, 0), "Night", new TimeSpan(0, 20, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "Id", "DishTypeId", "Name", "PeriodId" },
                values: new object[,]
                {
                    { 1, 1, "Eggs", 1 },
                    { 2, 1, "Steak", 2 },
                    { 3, 2, "Toast", 1 },
                    { 4, 2, "Potato", 2 },
                    { 5, 3, "Coffee", 1 },
                    { 6, 3, "Wine", 2 },
                    { 7, 4, "Cake", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishTypeId",
                table: "Dish",
                column: "DishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_Name",
                table: "Dish",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_PeriodId",
                table: "Dish",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DishType_Name",
                table: "DishType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Period_Name",
                table: "Period",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropTable(
                name: "Period");
        }
    }
}
