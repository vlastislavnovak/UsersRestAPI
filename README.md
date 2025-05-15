# UsersRestAPI

A simple ASP.NET Core Web API for managing users using Entity Framework Core.

---

## Features

- RESTful API to manage `User` entities
- Entity Framework Core
- Configuration via `appsettings.json`
- Logging of EF Core SQL queries to debug output

---

##  Getting Started

### Requirements

- .NET 8 or later
- Visual Studio 2022 or later

### Setup

**1. Clone the repository**
   ```bash
   git clone https://github.com/vlastislavnovak/UsersRestAPI.git
   ```
**2. Open the solution in Visual Studio**

**3. Configure the database**

Update the appsettings.json file with your connection string:
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "server=localhost;database=test;user=root;password="
   }
   ```
**4. Install dependencies**

If needed, restore NuGet packages:
   ```bash
   dotnet restore
   ```
   You may need to install EF Core tools:
   ```bash
   dotnet tool install dotnet-ef --create-manifest-if-needed
   ```

**5. Run database migrations**

Ensure your database is created and migrations are applied:

   ```bash
   dotnet ef database update
   ```
**6. Run the application**

## API Endpoints

| Method | Endpoint                  | Description               |
|--------|---------------------------|---------------------------|
| GET    | `/api/user/get?id={id}`   | Get a user by ID          |