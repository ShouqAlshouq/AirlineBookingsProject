using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingsProject.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeededUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U004");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U005");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { "U001", 0, "918b3172-764f-457e-bb74-7a66e023a41f", "ali@mail.com", false, "Ali Ahmed", false, null, null, null, "1234", null, "0501111111", false, "User", "630f9c77-e18c-4a37-8f88-a63a8609f0a6", false, null, "noimage.jpg" },
                    { "U002", 0, "cf704c38-7dc7-4127-ab23-3b479708f51d", "sara@mail.com", false, "Sara Khan", false, null, null, null, "1234", null, "0502222222", false, "User", "5ca7147f-d926-4c2a-a7eb-b90a5d1d9f0e", false, null, "noimage.jpg" },
                    { "U003", 0, "96ee3c62-b36a-4a0e-ba62-8a61716a0e0b", "john@mail.com", false, "John Smith", false, null, null, null, "1234", null, "0503333333", false, "User", "ddb1abd2-2555-47a5-aef0-8a14c9a91c2b", false, null, "noimage.jpg" },
                    { "U004", 0, "97946ec6-b9f5-4870-a8fe-4eafb263c8ba", "fatima@mail.com", false, "Fatima Noor", false, null, null, null, "1234", null, "0504444444", false, "User", "9eccd61a-ff7a-4309-84a7-d0793f1b5add", false, null, "noimage.jpg" },
                    { "U005", 0, "bd76b31e-1c55-4eb4-b1a8-9d42b4fff5fa", "admin@mail.com", false, "Admin User", false, null, null, null, "admin", null, "0505555555", false, "Admin", "382aae75-2b58-4a02-a114-57a767709887", false, null, "noimage.jpg" }
                });
        }
    }
}
