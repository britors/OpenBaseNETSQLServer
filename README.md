# OpenBaseNET SQLServer Template

![GitHub repo size](https://img.shields.io/github/repo-size/britors/OpenBaseNETSqlServer)
![NuGet Version](https://img.shields.io/nuget/v/w3ti.OpenBaseNET.SQLServer.Template.svg)
![GitHub language count](https://img.shields.io/github/languages/count/britors/OpenBaseNETSqlServer)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

> Template .NET 10 para criação rápida de Web APIs robustas com Arquitetura Limpa, DDD, CQRS e SQL Server.

Iniciar um novo projeto exige muita configuração repetitiva: estruturar as camadas, configurar o acesso a dados, definir pipelines de validação, conectar o logger, etc. Este template elimina esse trabalho inicial. Com um único comando, você obtém uma solução .NET completa e pronta para produção — seu foco fica nas regras de negócio.

---

## Arquitetura

O template segue os princípios de **Clean Architecture** com **Domain-Driven Design (DDD)**, organizando as responsabilidades em camadas independentes e testáveis.

```
MinhaApi/
├── src/
│   ├── MinhaApi.Domain          # Entidades, interfaces, serviços de domínio
│   ├── MinhaApi.Application     # Casos de uso, comandos, queries, DTOs
│   ├── MinhaApi.Infrastructure  # EF Core, Dapper, repositórios, UoW
│   └── MinhaApi.API             # Controllers, middlewares, Program.cs
└── tests/
    └── MinhaApi.Tests.Unit      # Testes unitários
```

| Camada | Responsabilidade |
|---|---|
| **Domain** | Entidades de negócio, interfaces dos repositórios e serviços de domínio. Não depende de nenhuma outra camada. |
| **Application** | Casos de uso via CQRS (commands e queries). Orquestra o domínio sem conhecer detalhes de infraestrutura. |
| **Infrastructure** | Implementações concretas: EF Core, Dapper, Unit of Work, resiliência com Polly, Serilog. |
| **API** | Entrada e saída da aplicação: Controllers, tratamento global de exceções, Swagger. |

---

## Funcionalidades

### Acesso a Dados
- **Entity Framework Core 10** com extensões para retry automático
- **Dapper** integrado para queries SQL de alta performance
- **Repository Pattern** genérico com suporte a paginação, filtros e includes
- **Unit of Work** para controle transacional com suporte a EF Core + Dapper na mesma transação

### CQRS e Mediator
- **MediatR 14** para separação de commands e queries
- **Pipeline Behaviors** pré-configurados:
  - `ValidationBehaviour` — executa validações FluentValidation antes de qualquer handler
  - `LoggingBehaviour` — registro automático de cada request processada

### Validação
- **FluentValidation** integrado ao pipeline do MediatR — erros retornam automaticamente como `422 Unprocessable Entity`

### Mapeamento
- **AutoMapper** configurado via injeção de dependência, com suporte a `null` em destinos e coleções

### Resiliência
- **Polly** com pipeline de retry exponencial com jitter (3 tentativas, delay inicial de 2s) para:
  - Operações SQL Server (via Dapper e EF Core)
  - Chamadas HTTP
  - Azure Storage

### Observabilidade
- **Serilog** com saída estruturada em JSON (formato `CompactJsonFormatter`)
- Enriquecimento automático com nome da máquina e nome do ambiente
- Configuração por `appsettings.json`
- Log automático de operações de repositório (add, update, remove, query, execute)

### Tratamento de Exceções
- **GlobalExceptionHandlerMiddleware** com resposta no padrão **RFC 9457 (ProblemDetails)**:
  - `ValidationException` → `422 Unprocessable Entity`
  - `KeyNotFoundException` → `404 Not Found`
  - `ArgumentException` → `400 Bad Request`
  - Demais exceções → `500 Internal Server Error`

### API e Documentação
- **Swagger / OpenAPI** configurado e disponível em ambiente de desenvolvimento
- **HTTPS** e autenticação pré-configurados no pipeline

### Testes
- Projeto de testes unitários com **xUnit**, **Moq** e **Coverlet**

---

## Tecnologias

| Pacote | Versão |
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

## Como Usar

### Pré-requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) ou superior
- SQL Server (local ou remoto)

### 1. Instalar o template

```bash
dotnet new install w3ti.OpenBaseNET.SQLServer.Template
```

### 2. Criar um novo projeto

```bash
mkdir MinhaApi
cd MinhaApi
dotnet new openbasenet-sql -n MinhaApi
```

### 3. Configurar a connection string

Edite `src/MinhaApi.Presentation.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "OpenBaseSQLServer": "Server=.;Database=MinhaApi;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 4. Executar

```bash
dotnet run --project src/MinhaApi.Presentation.Api/MinhaApi.Presentation.Api.csproj
```

A API estará disponível com Swagger em `https://localhost:{porta}/swagger`.

---

## Contato e Feedback

Rodrigo S. Brito — [rodrigo@w3ti.com.br](mailto:rodrigo@w3ti.com.br)

Feedbacks e contribuições são sempre bem-vindos.
