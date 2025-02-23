using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HSsASAJHUFFjidscdjjuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TourPackages_PackageId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Reservations",
                newName: "TourPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PackageId",
                table: "Reservations",
                newName: "IX_Reservations_TourPackageId");

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

            migrationBuilder.RenameColumn(
                name: "TourPackageId",
                table: "Reservations",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TourPackageId",
                table: "Reservations",
                newName: "IX_Reservations_PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TourPackages_PackageId",
                table: "Reservations",
                column: "PackageId",
                principalTable: "TourPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
