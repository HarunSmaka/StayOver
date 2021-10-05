using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class seedAccommodationOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationOffers_Accommodations_AccommodationId",
                table: "AccommodationOffers");

            migrationBuilder.DropIndex(
                name: "IX_AccommodationOffers_AccommodationId",
                table: "AccommodationOffers");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "AccommodationOffers");

            migrationBuilder.AddColumn<bool>(
                name: "Included",
                table: "AccommodationOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Included",
                table: "AccommodationOffers");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "AccommodationOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationOffers_AccommodationId",
                table: "AccommodationOffers",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationOffers_Accommodations_AccommodationId",
                table: "AccommodationOffers",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "AccommodationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
