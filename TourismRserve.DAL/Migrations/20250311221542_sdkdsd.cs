using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismRserve.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sdkdsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageComment_AspNetUsers_UserId",
                table: "PackageComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageComment_TourPackages_PackageId",
                table: "PackageComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageComment",
                table: "PackageComment");

            migrationBuilder.RenameTable(
                name: "PackageComment",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_PackageComment_UserId",
                table: "comments",
                newName: "IX_comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageComment_PackageId",
                table: "comments",
                newName: "IX_comments_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_TourPackages_PackageId",
                table: "comments",
                column: "PackageId",
                principalTable: "TourPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_TourPackages_PackageId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "PackageComment");

            migrationBuilder.RenameIndex(
                name: "IX_comments_UserId",
                table: "PackageComment",
                newName: "IX_PackageComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_PackageId",
                table: "PackageComment",
                newName: "IX_PackageComment_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageComment",
                table: "PackageComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageComment_AspNetUsers_UserId",
                table: "PackageComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageComment_TourPackages_PackageId",
                table: "PackageComment",
                column: "PackageId",
                principalTable: "TourPackages",
                principalColumn: "Id");
        }
    }
}
