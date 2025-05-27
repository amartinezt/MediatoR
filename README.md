# TaskBoard

**TaskBoard** is a modular and scalable .NET Web API designed using the principles of **Clean Architecture** and powered by the **Mediator pattern** via [MediatR](https://github.com/jbogard/MediatR).  
It provides a base framework for task management APIs with clear separation of concerns.

---

## 🧱 Architecture

This solution follows **Clean Architecture** with the following layers:

- **API Layer** (`TaskBoard.API`)  
  Exposes HTTP endpoints via controllers. Includes Swagger UI, custom middleware, and dependency injection configuration.

- **Application Layer** (`TaskBoard.Application`)  
  Contains CQRS logic with **Commands** and **Queries** handled by MediatR. Also includes response models.

- **Domain Layer** (`TaskBoard.Domain`)  
  Defines core domain models and interfaces, remaining independent of any infrastructure or application logic.

- **Infrastructure Layer** (`TaskBoard.Infrastructure`)  
  Contains database context (Entity Framework Core), migrations, and repository implementations.

- **Test Layer** (`TaskBoard.Tests`)  
  Placeholder for unit and integration tests.

---

## 💡 Key Features

- ✅ **CQRS with MediatR**  
  Commands and queries are handled using MediatR for clean separation and decoupling.

- ✅ **Entity Framework Core**  
  Uses EF Core with SQL Server for data persistence.

- ✅ **Custom Middleware**  
  Centralized exception handling.

- ✅ **Swagger UI**  
  Enabled in development for testing and documentation.

- ✅ **Environment-Specific Configuration**  
  Uses `appsettings.Development.json` for shareable config.

---

## 🛠️ Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or Docker)
- Visual Studio 2022+

### Run the App

```bash
dotnet build
dotnet run --project TaskBoard.API
