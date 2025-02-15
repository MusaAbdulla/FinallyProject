using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HSHSSBG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourPackageId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TourPackageId",
                table: "Reservations",
                column: "TourPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TourPackages_TourPackageId",
                table: "Reservations",
                column: "TourPackageId",
                principalTable: "TourPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TourPackages_TourPackageId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TourPackageId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TourPackageId",
                table: "Reservations");
        }
    }
}
