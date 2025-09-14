# Booking System

A simple booking system built with **ASP.NET Core** and **Entity Framework Core**, featuring authentication, authorization, reservations, and trips management.

---

## 🚀 Requirements
- .NET 9 SDK
- SQL Server
- Visual Studio / Rider / VS Code

---

## ⚙️ Setup

### 1. Configure Database
Update the connection string in `appsettings.json` if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Booking;Trusted_Connection=True;TrustServerCertificate=True;"
}
2. Apply Migrations
Run the following command to create the database:


dotnet ef database update
3. Run the Project
Start the project with:


dotnet run
The API will be available at:


http://localhost:5024
🌱 Data Seeding
The project automatically seeds initial data on startup via DataSeeder.SeedAsync in Program.cs.

Seeded Roles:
Admin

User

Seeded Users:
Admin User

Username: admin

Email: admin@example.com

Password: Admin123!

Normal User

Username: user1

Email: user1@example.com

Password: User123!

Seeded Trips:
Luxor Adventure – Price: 500

Sharm El-Sheikh Tour – Price: 800

📖 Swagger API Docs
After running the project, Swagger UI will be available at:


http://localhost:5024/swagger
Use this to explore and test the API endpoints.

✅ Features
User authentication & authorization (JWT + Identity)

Role management

Reservations management (Create, Update, Delete)

Trips management

API documentation with Swagger

Database seeding for quick start

🛠️ Tech Stack
ASP.NET Core 9

Entity Framework Core

MediatR

FluentValidation

Swagger