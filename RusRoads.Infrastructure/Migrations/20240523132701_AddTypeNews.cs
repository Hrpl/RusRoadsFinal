using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "News");
        }
    }
}
