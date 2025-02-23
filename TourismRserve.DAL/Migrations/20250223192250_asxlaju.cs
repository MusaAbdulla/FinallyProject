using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class asxlaju : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Reservations",
                newName: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Reservations",
                newName: "Email");
        }
    }
}
