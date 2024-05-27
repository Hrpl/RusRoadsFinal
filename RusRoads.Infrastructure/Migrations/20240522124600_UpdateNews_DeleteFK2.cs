using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNews_DeleteFK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmpoloyeeGuid",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmpoloyeeGuid",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
