using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingsProject.Migrations
{
    /// <inheritdoc />
    public partial class SyncFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5e275385-ad3f-475d-88bd-080ad01f7baf", "5ea014f4-c2aa-405a-a688-691acb765933" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f802912f-fe2b-4ec0-bb85-6cef08750db7", "af628d29-655c-47d1-a219-0db185ef4dd6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b8f7fc49-6b08-4426-a494-6583c1c28ee3", "19390616-3096-4d20-ae1d-df575fe18f01" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a125332a-a89e-46f4-a79e-265de1cf8071", "7a332223-da47-4d9d-a30b-34eaca430869" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03eebcab-5ea9-4363-b95a-6f52a6f6f60d", "facfa480-18cb-484d-a902-41154f8f8e11" });
        }
    }
}
