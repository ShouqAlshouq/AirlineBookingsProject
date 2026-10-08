using AirlineBookingsProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingsProject.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "R001", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "R002", Name = "User", NormalizedName = "USER" }
            );

            var admin = new User
            {
                Id = "U001",
                FullName = "Admin User",
                Email = "admin@mail.com",
                UserName = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                NormalizedUserName = "ADMIN@MAIL.COM",
                PhoneNumber = "0505555555",
                UserPhoto = "noimage.jpg",
                Role = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "U001",
                    RoleId = "R001"
                }
            );
            modelBuilder.Entity<Flight>().HasData(
                new Flight { FlightId = "F001", FlightNo = "EK202", FromCity = "Abu Dhabi", ToCity = "London", Date = new DateTime(2026, 6, 10), Time = new TimeSpan(10, 0, 0), Price = 1500 },
                new Flight { FlightId = "F002", FlightNo = "EY301", FromCity = "Dubai", ToCity = "Cairo", Date = new DateTime(2026, 6, 12), Time = new TimeSpan(7, 0, 0), Price = 900 },
                new Flight { FlightId = "F003", FlightNo = "QR105", FromCity = "Doha", ToCity = "Paris", Date = new DateTime(2026, 6, 15), Time = new TimeSpan(9, 0, 0), Price = 2000 },
                new Flight { FlightId = "F004", FlightNo = "BA450", FromCity = "London", ToCity = "New York", Date = new DateTime(2026, 6, 18), Time = new TimeSpan(2, 0, 0), Price = 2500 },
                new Flight { FlightId = "F005", FlightNo = "LH700", FromCity = "Frankfurt", ToCity = "Tokyo", Date = new DateTime(2026, 6, 20), Time = new TimeSpan(11, 0, 0), Price = 3000 }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingId = "B001", BookingDate = new DateTime(2026, 5, 1), Status = "Confirmed", UserId = "U001", FlightId = "F001" },
                new Booking { BookingId = "B002", BookingDate = new DateTime(2026, 5, 2), Status = "Confirmed", UserId = "U002", FlightId = "F002" },
                new Booking { BookingId = "B003", BookingDate = new DateTime(2026, 5, 3), Status = "Cancelled", UserId = "U003", FlightId = "F003" },
                new Booking { BookingId = "B004", BookingDate = new DateTime(2026, 5, 4), Status = "Confirmed", UserId = "U004", FlightId = "F004" },
                new Booking { BookingId = "B005", BookingDate = new DateTime(2026, 5, 5), Status = "Pending", UserId = "U001", FlightId = "F005" }
            );

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { PassengerId = "P001", FullName = "Ali Ahmed", PassportNo = "A1234567", Nationality = "UAE", BookingId = "B001" },
                new Passenger { PassengerId = "P002", FullName = "Sara Khan", PassportNo = "B2345678", Nationality = "India", BookingId = "B002" },
                new Passenger { PassengerId = "P003", FullName = "John Smith", PassportNo = "C3456789", Nationality = "UK", BookingId = "B003" },
                new Passenger { PassengerId = "P004", FullName = "Fatima Noor", PassportNo = "D4567890", Nationality = "UAE", BookingId = "B004" },
                new Passenger { PassengerId = "P005", FullName = "Ali Ahmed", PassportNo = "E5678901", Nationality = "UAE", BookingId = "B005" }
            );

            modelBuilder.Entity<Payment>().HasData(
               new Payment { PaymentId = "PAY001", PaymentDate = new DateTime(2026, 5, 1), Amount = 1500, Method = "Card", BookingId = "B001" },
               new Payment { PaymentId = "PAY002", PaymentDate = new DateTime(2026, 5, 2), Amount = 900, Method = "Cash", BookingId = "B002" },
               new Payment { PaymentId = "PAY003", PaymentDate = new DateTime(2026, 5, 3), Amount = 2000, Method = "Card", BookingId = "B003" },
               new Payment { PaymentId = "PAY004", PaymentDate = new DateTime(2026, 5, 4), Amount = 2500, Method = "Card", BookingId = "B004" },
               new Payment { PaymentId = "PAY005", PaymentDate = new DateTime(2026, 5, 5), Amount = 3000, Method = "Cash", BookingId = "B005" }
            );
        }
    }
}
