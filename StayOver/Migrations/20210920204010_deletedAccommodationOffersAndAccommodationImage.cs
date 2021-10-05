using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class deletedAccommodationOffersAndAccommodationImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImage");

            migrationBuilder.DropTable(
                name: "AccommodationOffers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationImage",
                columns: table => new
                {
                    AccommodationImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccommodationId = table.Column<int>(type: "int", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImage", x => x.AccommodationImageId);
                    table.ForeignKey(
                        name: "FK_AccommodationImage_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationOffers",
                columns: table => new
                {
                    AccommodationOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Included = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationOffers", x => x.AccommodationOfferId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImage_AccommodationId",
                table: "AccommodationImage",
                column: "AccommodationId");
        }
    }
}
