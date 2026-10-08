using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingsProject.Migrations
{
    /// <inheritdoc />
    public partial class security : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7206fc3-3611-4552-91d6-9ed22a40e602", "29c9037c-8a2e-46b3-880e-50b0c0c11a41" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c099968d-d234-45c6-8027-cc97df65ed70", "b0e4d35a-046a-4f44-9f63-39a629f46cab" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a12b17ea-891f-4d3a-9be0-87449b81e52f", "f8611fcb-ebdb-46a7-8985-6ec0ce4b7169" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9025c5a4-4cad-4edd-b287-545ed83d85dd", "07041799-26ba-4acf-94b1-791f9da382d0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1eec1d98-4476-4d79-8306-814ea205da30", "3713ba2d-d387-4f0b-979a-53fe914b0919" });
        }
    }
}
