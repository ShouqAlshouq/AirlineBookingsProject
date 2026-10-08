# ✈️ Airline Bookings

A data-driven airline booking website built with **ASP.NET Core MVC**. Visitors can browse and search flights; registered users can book a flight with passenger and payment details and manage their bookings and profile; admins manage flights and see a booking dashboard.

Final project for **CIA 4103** — Team 2.

---

## Features

### For everyone
- **All Flights** — browse every flight in the system
- **Search Flights** — filter by from-city, to-city and date; the site remembers your last search (cookies, 7 days)
- **Register / Login / Logout** — ASP.NET Core Identity; pick a profile picture from the built-in set

### For signed-in users
- **Book a flight** — enter passenger details (name, passport, nationality) and a payment method; the booking starts as *Pending*
- **My Bookings** — see your bookings with flight, passenger and payment info, and cancel one
- **My Profile** — update your name, phone number and profile picture

### For admins
- **Dashboard** — counts of confirmed / pending / cancelled bookings, passengers, flights and users
- **Add Flights**, **Manage Flights** (edit and delete), and **All Users**
- Admin pages are protected with `[Authorize(Roles = "Admin")]`; other users are sent to an *Access Denied* page

## Tech stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC on **.NET 9** (C#, Razor views) |
| Data | Entity Framework Core 9 (Code First + migrations) on **SQL Server LocalDB** |
| Auth | ASP.NET Core Identity (custom `User : IdentityUser`) with roles |
| State | Identity cookie · Session (`UserId`, `UserName`, `UserRole`, 30-min idle timeout) · Cookies (last search) |
| Validation | Data annotations + two custom attributes (`ValidDate`, `ValidDateResult`) |
| UI | Bootstrap, jQuery Validation |

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- **SQL Server LocalDB** (installed with Visual Studio's *ASP.NET and web development* / *Data storage* workloads). LocalDB is Windows-only — on macOS/Linux, point the connection string at another SQL Server instance (e.g. SQL Server in Docker).
- Visual Studio 2022 (17.13+) or 2026 — the solution uses the newer `.slnx` format — or the .NET CLI
- The EF Core CLI tool for the command-line route: `dotnet tool install --global dotnet-ef`

## Getting started

### 1. Clone

```bash
git clone https://github.com/<your-username>/AirlineBookingsProject.git
cd AirlineBookingsProject
```

### 2. Check the connection string

`AirlineBookingsProject/appsettings.json` already points at LocalDB:

```json
"ConnectionStrings": {
  "conn": "Server=(localdb)\\mssqllocaldb;Database=AirlineBookingDB;Trusted_Connection=True;"
}
```

If you use a different SQL Server, change it there (or override it with user-secrets / an environment variable rather than committing a password).

### 3. Create the database

The app does not create the database by itself — apply the migrations once:

```bash
dotnet ef database update --project AirlineBookingsProject
```

*(In Visual Studio: **Tools → NuGet Package Manager → Package Manager Console**, set the default project to `AirlineBookingsProject`, then run `Update-Database`.)*

### 4. Run

```bash
dotnet run --project AirlineBookingsProject
```

Open **http://localhost:5135** (or press **F5** in Visual Studio — the *IIS Express* profile uses http://localhost:29339).

> `launchSettings.json` runs the site in the **Production** environment, so you'll see the friendly error pages instead of detailed exceptions. Set `ASPNETCORE_ENVIRONMENT` to `Development` while debugging.

## Demo data & accounts

The migrations seed the roles (`Admin`, `User`), an admin account, and sample flights.

| Role | Email | Password |
|---|---|---|
| Admin | `admin@mail.com` | `Admin123!` |
| User | register your own on the **Register** page | — |

> ⚠️ These are **demo credentials** that live in the source code (`Data/AppDbContext.cs`). They are fine for a class project, but never deploy this app publicly without changing them.

The seeded flights are dated **June 2026**. For a realistic demo, add fresh flights from **Admin → Add Flights**.

## Data model

```
User (Identity) 1 ──< Booking >── 1 Flight
                          │
                          ├──< Passenger
                          └── 1 Payment
```

| Table | Key format | Main fields |
|---|---|---|
| `Flights` | `F001` | FlightNo (e.g. `EK202`), FromCity, ToCity, Date, Time, Price (0–99,999) |
| `Bookings` | `B001` | BookingDate, Status (*Pending / Confirmed / Cancelled*), UserId, FlightId |
| `Passengers` | `P001` | FullName, PassportNo, Nationality, BookingId |
| `Payments` | `PAY001` | PaymentDate, Amount, Method (*Card / Cash*), BookingId |
| `AspNetUsers` | `U001` | FullName, UserPhoto, Role (+ standard Identity columns) |

## Project structure

```
AirlineBookingsProject/                 ← repo root
├── AirlineBookingsProject.slnx
└── AirlineBookingsProject/
    ├── Program.cs                      # DI, Identity, session, routing, error handling
    ├── appsettings.json                # connection string ("conn")
    ├── Controllers/
    │   ├── AccountController.cs        # register, login, logout, access denied
    │   ├── FlightsController.cs        # list + search (remembers last search in cookies)
    │   ├── BookingsController.cs       # book, my bookings, cancel
    │   ├── UsersController.cs          # profile
    │   ├── AdminController.cs          # dashboard, flight CRUD, user list  [Admin only]
    │   ├── HomeController.cs
    │   └── ErrorController.cs          # custom 404 / error pages
    ├── Models/                         # Flight, Booking, Passenger, Payment, User
    ├── Data/AppDbContext.cs            # EF Core context + seed data
    ├── CustomValidations/              # ValidDate, ValidDateResult
    ├── Migrations/                     # database history
    ├── Views/                          # Razor views per controller + Shared layout
    └── wwwroot/                        # css, js, images, Bootstrap & jQuery
```

## How state is handled

- **Identity** keeps the user logged in (authentication cookie) and enforces roles.
- **Session** stores `UserId`, `UserName` and `UserRole` after login; bookings are linked to the signed-in user through it.
- **Cookies** remember the last flight search (from, to, date) for 7 days; they're cleared on logout.

## Notes & limitations

- **No real payment processing** — a `Payment` row simply records the amount and chosen method.
- **Bookings are created as *Pending*** — there is no confirmation workflow yet.
- **Record IDs are generated from row counts** (`B` + count + 1), which is fine for a demo but can collide if rows are deleted.
- **LocalDB only by default** — see *Requirements* for other SQL Server setups.

## Team
- **Shouq Alshouq**
- **Dhoha Alhammadi**

*Course project — CIA 4103.*
