using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingsProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "918b3172-764f-457e-bb74-7a66e023a41f", "630f9c77-e18c-4a37-8f88-a63a8609f0a6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cf704c38-7dc7-4127-ab23-3b479708f51d", "5ca7147f-d926-4c2a-a7eb-b90a5d1d9f0e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96ee3c62-b36a-4a0e-ba62-8a61716a0e0b", "ddb1abd2-2555-47a5-aef0-8a14c9a91c2b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "97946ec6-b9f5-4870-a8fe-4eafb263c8ba", "9eccd61a-ff7a-4309-84a7-d0793f1b5add" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bd76b31e-1c55-4eb4-b1a8-9d42b4fff5fa", "382aae75-2b58-4a02-a114-57a767709887" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "071f036e-a25f-4d35-95e9-524b1a8d5dd5", "d47ee656-4bcf-46f4-a05c-8048e8dad200" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1e43b2f5-96f4-4aaa-a2fc-10cb69274dcb", "5bb3d455-704d-4e4d-8481-dc20bbc0decb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9304d95-1c2a-4632-b497-06e5d38c171d", "d2d5fde0-1fdf-462e-8f4f-bbd037112ff0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1f16995c-933e-4e14-9f1b-ad0d14f39e9f", "edc72cba-d85c-4f73-b92b-2842bf925186" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "899a0070-53eb-4473-8656-5a1feea1dcde", "ab05d5ee-c815-4fb9-8aba-c03b67489b04" });
        }
    }
}
