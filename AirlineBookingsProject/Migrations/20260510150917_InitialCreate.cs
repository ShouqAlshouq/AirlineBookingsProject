using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingsProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPhoto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Passengers_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Date", "FlightNo", "FromCity", "Price", "Time", "ToCity" },
                values: new object[,]
                {
                    { "F001", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "EK202", "Abu Dhabi", 1500.0, new TimeSpan(0, 10, 0, 0, 0), "London" },
                    { "F002", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EY301", "Dubai", 900.0, new TimeSpan(0, 7, 0, 0, 0), "Cairo" },
                    { "F003", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "QR105", "Doha", 2000.0, new TimeSpan(0, 9, 0, 0, 0), "Paris" },
                    { "F004", new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA450", "London", 2500.0, new TimeSpan(0, 2, 0, 0, 0), "New York" },
                    { "F005", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "LH700", "Frankfurt", 3000.0, new TimeSpan(0, 11, 0, 0, 0), "Tokyo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { "U001", 0, "f7206fc3-3611-4552-91d6-9ed22a40e602", "ali@mail.com", false, "Ali Ahmed", false, null, null, null, "1234", null, "0501111111", false, "User", "29c9037c-8a2e-46b3-880e-50b0c0c11a41", false, null, "noimage.jpg" },
                    { "U002", 0, "c099968d-d234-45c6-8027-cc97df65ed70", "sara@mail.com", false, "Sara Khan", false, null, null, null, "1234", null, "0502222222", false, "User", "b0e4d35a-046a-4f44-9f63-39a629f46cab", false, null, "noimage.jpg" },
                    { "U003", 0, "a12b17ea-891f-4d3a-9be0-87449b81e52f", "john@mail.com", false, "John Smith", false, null, null, null, "1234", null, "0503333333", false, "User", "f8611fcb-ebdb-46a7-8985-6ec0ce4b7169", false, null, "noimage.jpg" },
                    { "U004", 0, "9025c5a4-4cad-4edd-b287-545ed83d85dd", "fatima@mail.com", false, "Fatima Noor", false, null, null, null, "1234", null, "0504444444", false, "User", "07041799-26ba-4acf-94b1-791f9da382d0", false, null, "noimage.jpg" },
                    { "U005", 0, "1eec1d98-4476-4d79-8306-814ea205da30", "admin@mail.com", false, "Admin User", false, null, null, null, "admin", null, "0505555555", false, "Admin", "3713ba2d-d387-4f0b-979a-53fe914b0919", false, null, "noimage.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "FlightId", "Status", "UserId" },
                values: new object[,]
                {
                    { "B001", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "F001", "Confirmed", "U001" },
                    { "B002", new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "F002", "Confirmed", "U002" },
                    { "B003", new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "F003", "Cancelled", "U003" },
                    { "B004", new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "F004", "Confirmed", "U004" },
                    { "B005", new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "F005", "Pending", "U001" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "BookingId", "FullName", "Nationality", "PassportNo" },
                values: new object[,]
                {
                    { "P001", "B001", "Ali Ahmed", "UAE", "A1234567" },
                    { "P002", "B002", "Sara Khan", "India", "B2345678" },
                    { "P003", "B003", "John Smith", "UK", "C3456789" },
                    { "P004", "B004", "Fatima Noor", "UAE", "D4567890" },
                    { "P005", "B005", "Ali Ahmed", "UAE", "E5678901" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BookingId", "Method", "PaymentDate" },
                values: new object[,]
                {
                    { "PAY001", 1500.0, "B001", "Card", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PAY002", 900.0, "B002", "Cash", new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PAY003", 2000.0, "B003", "Card", new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PAY004", 2500.0, "B004", "Card", new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PAY005", 3000.0, "B005", "Cash", new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
