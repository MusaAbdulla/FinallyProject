using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HSHAoJSKJjhhjswdsSDSDSDSasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extra",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Extra",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
