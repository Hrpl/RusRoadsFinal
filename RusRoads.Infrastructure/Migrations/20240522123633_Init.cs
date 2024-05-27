using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpoloyeeGuid = table.Column<int>(type: "int", nullable: false),
                    EmployeeGuid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_News_Employees_EmployeeGuid",
                        column: x => x.EmployeeGuid,
                        principalTable: "Employees",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_EmployeeGuid",
                table: "News",
                column: "EmployeeGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
