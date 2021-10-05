using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class removeSeedAOdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AccommodationOffers",
                keyColumn: "AccommodationOfferId",
                keyValue: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccommodationOffers",
                columns: new[] { "AccommodationOfferId", "Icon", "Included", "Name" },
                values: new object[,]
                {
                    { 1, "fas fa - smoking - ban", false, "No smoking" },
                    { 2, "fas fa - fan", false, "Air conditioner" },
                    { 3, "fas fa-paw", false, "Pets allowed" },
                    { 4, "fas fa-parking", false, "Free parking" },
                    { 5, "fas fa - tv", false, "TV" },
                    { 6, "fas fa - wifi", false, "Wi-Fi" },
                    { 7, "fas fa - utensils", false, "Breakfast included" },
                    { 8, "fas fa - toilet", false, "Private Toilet" },
                    { 9, "fas fa - video", false, "Video surveillance" }
                });
        }
    }
}
