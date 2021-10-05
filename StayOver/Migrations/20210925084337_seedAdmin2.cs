using Microsoft.EntityFrameworkCore.Migrations;

namespace StayOver.Migrations
{
    public partial class seedAdmin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "536fe29a-5def-4232-9033-50753383ce06", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG/lr5ys8PXUDXQrO/naGotMQZ/vHHeYApvbA9xzoNFaMaRJ8+3woKEgIqwjEfuwXw==", "06123456", "5530d7a3-3010-4dbf-8ae2-0aa6cf71319b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "1754ed89-63c7-4bb4-96e1-27c548bbc270", null, "AQAAAAEAACcQAAAAEBKQn8KPXKTM7SHlT9/yvE/0RqbxcdEhx4IRJvj8t8CYmwDK/2ymMlf6KXDW1Zuqcw==", null, "d189dd2f-3b7e-4303-98d4-b27f5849b6a4" });
        }
    }
}
