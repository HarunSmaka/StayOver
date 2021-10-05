using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class updateNormalizedNameAndIdOfUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "347923f0-asd2–42fe-afbf-58kikkmk72ck3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b0386b9-7a6a-426a-a71e-e191ee13a306", "6b0386b9-7a6a-426a-a71e-e191ee13a306", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bae9188c-2f6b-491d-b091-2eca5ad7592c", "AQAAAAEAACcQAAAAEJ0PzzglekAwdH3ENyrHuEb18/WvnMbdEMhkMT9XduBOc8+t63t73bmdr34YMH3vfg==", "c87204e5-1789-485c-9d74-c60483a9d4b6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0386b9-7a6a-426a-a71e-e191ee13a306");

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
    }
}
