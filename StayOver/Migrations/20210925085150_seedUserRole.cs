using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class seedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "347923f0-asd2–42fe-afbf-58kikkmk72ck3", "347923f0-asd2–42fe-afbf-58kikkmk72ck3", "User", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47472797-f61b-47d1-840b-d42cc99808c5", "AQAAAAEAACcQAAAAEG0thVCnsFlof/QoxAU87QSF1odR7g74atClSJDwK5cD6xozGfyj3sFuHZ4wpqMH7Q==", "e9675040-4cce-424d-a77b-6159a541ffc3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "347923f0-asd2–42fe-afbf-58kikkmk72ck3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "536fe29a-5def-4232-9033-50753383ce06", "AQAAAAEAACcQAAAAEG/lr5ys8PXUDXQrO/naGotMQZ/vHHeYApvbA9xzoNFaMaRJ8+3woKEgIqwjEfuwXw==", "5530d7a3-3010-4dbf-8ae2-0aa6cf71319b" });
        }
    }
}
