using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class addedAccommodationToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AccommodationId",
                table: "Reservations",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accommodations_AccommodationId",
                table: "Reservations",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "AccommodationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accommodations_AccommodationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AccommodationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Reservations");
        }
    }
}
