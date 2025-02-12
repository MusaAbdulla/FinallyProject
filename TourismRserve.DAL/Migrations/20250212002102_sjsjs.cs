using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sjsjs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Slides");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Slides");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
