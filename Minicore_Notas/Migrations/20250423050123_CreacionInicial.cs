using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Minicore_Notas.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateOnly>(type: "date", nullable: false),
                    End = table.Column<DateOnly>(type: "date", nullable: false),
                    Weigh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeValue = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "End", "Start", "Weigh" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 11, 25), new DateOnly(2023, 9, 27), 25 },
                    { 2, new DateOnly(2024, 1, 8), new DateOnly(2023, 11, 26), 35 },
                    { 3, new DateOnly(2024, 9, 30), new DateOnly(2024, 1, 9), 40 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Juan" },
                    { 2, "Pedro" },
                    { 3, "Maria" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Date", "GradeValue", "Name", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 10, 1), 8.5, "Deber 1", 1 },
                    { 2, new DateOnly(2023, 10, 2), 9.5, "Prueba 1", 1 },
                    { 3, new DateOnly(2023, 10, 3), 10.0, "Control 1", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
