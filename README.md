# OpenBaseNET SQLServer Template

![GitHub repo size](https://img.shields.io/github/repo-size/britors/OpenBaseNETSqlServer)
![NuGet Version](https://img.shields.io/nuget/v/w3ti.OpenBaseNET.SQLServer.Template.svg)
![GitHub language count](https://img.shields.io/github/languages/count/britors/OpenBaseNETSqlServer)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

> .NET 10 template for quickly building robust Web APIs with Clean Architecture, DDD, CQRS, and SQL Server.

Starting a new project requires a lot of repetitive setup: structuring layers, configuring data access, defining validation pipelines, wiring up the logger, and so on. This template eliminates that boilerplate. With a single command, you get a complete, production-ready .NET solution — so you can focus on business logic.

---

## Architecture

The template follows **Clean Architecture** principles with **Domain-Driven Design (DDD)**, organizing responsibilities into independent, testable layers.

```
MyApi/
├── src/
│   ├── MyApi.Domain          # Entities, interfaces, domain services
│   ├── MyApi.Application     # Use cases, commands, queries, DTOs
│   ├── MyApi.Infrastructure  # EF Core, Dapper, repositories, UoW
│   └── MyApi.API             # Controllers, middlewares, Program.cs
└── tests/
    └── MyApi.Tests.Unit      # Unit tests
```

| Layer | Responsibility |
|---|---|
| **Domain** | Business entities, repository interfaces, and domain services. Has no dependencies on any other layer. |
| **Application** | Use cases via CQRS (commands and queries). Orchestrates the domain without knowing infrastructure details. |
| **Infrastructure** | Concrete implementations: EF Core, Dapper, Unit of Work, resilience with Polly, Serilog. |
| **API** | Application entry/exit point: Controllers, global exception handling, Swagger. |

---

## Features

### Data Access
- **Entity Framework Core 10** with extensions for automatic retry
- **Dapper** integrated for high-performance SQL queries
- Generic **Repository Pattern** with support for pagination, filters, and includes
- **Unit of Work** for transactional control with EF Core + Dapper in the same transaction

### CQRS and Mediator
- **MediatR 14** for command and query separation
- Pre-configured **Pipeline Behaviors**:
  - `ValidationBehaviour` — runs FluentValidation before any handler
  - `LoggingBehaviour` — automatic logging for every processed request

### Validation
- **FluentValidation** integrated into the MediatR pipeline — errors are automatically returned as `422 Unprocessable Entity`

### Mapping
- **AutoMapper** configured via dependency injection, with support for `null` destinations and collections

### Resilience
- **Polly** with an exponential retry pipeline with jitter (3 attempts, 2s initial delay) for:
  - SQL Server operations (via Dapper and EF Core)
  - HTTP calls
  - Azure Storage

### Observability
- **Serilog** with structured JSON output (`CompactJsonFormatter`)
- Automatic enrichment with machine name and environment name
- Configurable via `appsettings.json`
- Automatic logging of repository operations (add, update, remove, query, execute)

### Exception Handling
- **GlobalExceptionHandlerMiddleware** with responses following **RFC 9457 (ProblemDetails)**:
  - `ValidationException` → `422 Unprocessable Entity`
  - `KeyNotFoundException` → `404 Not Found`
  - `ArgumentException` → `400 Bad Request`
  - All other exceptions → `500 Internal Server Error`

### API and Documentation
- **Swagger / OpenAPI** configured and available in the development environment
- **HTTPS** and authentication pre-configured in the pipeline

### Testing
- Unit test project with **xUnit**, **Moq**, and **Coverlet**

---

## Technologies

| Package | Version |
|---|---|
| .NET | 10 |
| Entity Framework Core | 10 |
| MediatR | 14 |
| FluentValidation | — |
| AutoMapper | 16 |
| Dapper | — |
| Polly | — |
| Serilog | — |
| xUnit | 2.9 |
| Moq | 4.20 |

---

## Getting Started

### Prerequisites

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) or later
- SQL Server (local or remote)

### 1. Install the template

```bash
dotnet new install w3ti.OpenBaseNET.SQLServer.Template
```

### 2. Create a new project

```bash
mkdir MyApi
cd MyApi
dotnet new openbasenet-sql -n MyApi
```

### 3. Configure the connection string

Edit `src/MyApi.Presentation.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "OpenBaseSQLServer": "Server=.;Database=MyApi;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 4. Run

```bash
dotnet run --project src/MyApi.Presentation.Api/MyApi.Presentation.Api.csproj
```

The API will be available with Swagger at `https://localhost:{port}/swagger`.

---

## Contact and Feedback

Rodrigo S. Brito — [rodrigo@w3ti.com.br](mailto:rodrigo@w3ti.com.br)

Feedback and contributions are always welcome.
