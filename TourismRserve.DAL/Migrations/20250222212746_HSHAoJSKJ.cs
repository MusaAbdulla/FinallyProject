using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HSHAoJSKJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calendar",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Reservations",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId1",
                table: "Reservations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId1",
                table: "Reservations",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "Calendar",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
