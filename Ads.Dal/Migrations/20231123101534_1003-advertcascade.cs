using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Dal.Migrations
{
    /// <inheritdoc />
    public partial class _1003advertcascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertComments_Adverts_AdvertId",
                table: "AdvertComments");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertComments_Adverts_AdvertId",
                table: "AdvertComments",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertComments_Adverts_AdvertId",
                table: "AdvertComments");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertComments_Adverts_AdvertId",
                table: "AdvertComments",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
