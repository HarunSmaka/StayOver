using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class propertyAddedToAccommodationOfferClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "AccommodationOffers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "AccommodationOffers");
        }
    }
}
