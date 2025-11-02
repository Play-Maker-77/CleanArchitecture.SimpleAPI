# 🧱 CleanArchitecture.SimpleAPI

A modular **Clean Architecture** project built with **.NET 8**, **Entity Framework Core**, and **SQL Server** — demonstrating a clean separation between Domain, Application, Infrastructure, and Presentation layers.

---

## 📁 Project Structure

CleanArchitecture.SimpleAPI/
│
├── Domain/ # Entities and Repository Interfaces
├── Application/ # DTOs, Services, Business Logic
├── Infrastructure/ # Database, EF Core, and Repositories
├── Presentation/ # ASP.NET Core Web API (Startup Layer)
│
├── CleanArchitecture.SimpleAPI.sln
└── README.md


---

## ⚙️ Prerequisites

Before running the project, ensure you have:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)  

Install EF tools (if not installed):
```bash
dotnet tool install --global dotnet-ef

📦 Package Installation
```
📁 Infrastructure Project
```
Open the Package Manager Console and install these packages (if not already):
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.Extensions.Configuration
Install-Package Microsoft.Extensions.DependencyInjection
```

📁 Presentation Project
```
Install-Package Microsoft.AspNetCore.OpenApi
Install-Package Swashbuckle.AspNetCore
```

🗃️ Database Migration Setup
```
1- Open Package Manager Console (PMC) in Visual Studio
(from menu: Tools → NuGet Package Manager → Package Manager Console)

2- Set Default Project:
Select Infrastructure from the dropdown.

3- Run Migration Command:
   Add-Migration InitialCreate -StartupProject Presentation


4- Apply the Migration to SQL Server:

Update-Database -StartupProject Presentation

💡 Make sure your appsettings.json in the Presentation project contains a valid SQL connection string:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CleanArchDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

🚀 Running the API
From Visual Studio:
- Set Presentation as the Startup Project
- Run the solution → Swagger UI should open automatically
- at: https://localhost:5001/swagger

🧩 API Endpoints
HTTPMethod	   Endpoint	          Description
POST	         /api/users	        Add a new user
GET	           /api/users	        Get all users
GET	           /api/users/{id}	  Get user by ID
DELETE	       /api/users/{id}	  Delete a user


🧠 Architecture Summary
- Domain → Core business entities (no dependencies)
- Application → Use cases, DTOs, business rules
- Infrastructure → Data access, repositories, EF Core
- Presentation → API layer, dependency injection, controllers


🛠️ Development Notes
- Uses Dependency Injection across all layers
- Repository pattern implemented in Infrastructure
- Uses EF Core for ORM
- API follows RESTful principles
