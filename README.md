# OpenBaseNET para SQL Server

![GitHub repo size](https://img.shields.io/github/repo-size/britors/OpenBaseNETSqlServer)
![GitHub top language](https://img.shields.io/github/languages/top/britors/OpenBaseNETSqlServer)
![GitHub language count](https://img.shields.io/github/languages/count/britors/OpenBaseNETSqlServer)
![GitHub last commit](https://img.shields.io/github/last-commit/britors/OpenBaseNETSqlServer)
![GitHub issues](https://img.shields.io/github/issues/britors/OpenBaseNETSqlServer)
![GitHub](https://img.shields.io/github/license/britors/OpenBaseNETSqlServer)
![GitHub forks](https://img.shields.io/github/forks/britors/OpenBaseNETSqlServer?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/britors/OpenBaseNETSqlServer?style=social)
![GitHub watchers](https://img.shields.io/github/watchers/britors/OpenBaseNETSqlServer?style=social)
![GitHub followers](https://img.shields.io/github/followers/britors?style=social)

![file-uEaANJlNJk9YwI8j1vBAYg1W](https://github.com/britors/OpenBaseNETSqlServer/assets/183213/a69c95be-d9ff-494f-baa7-2c7baed0f0a3)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

> OpenBaseNET para SQL Server é um template para projetos .net 9 usando base de dados Microsoft SQL Server.
O template foi construído devido a necessidade de criar projetos  forma rápida e prática.

## Como Começar

Siga os passos abaixo para executar o projeto localmente.

### Pré-requisitos

* [.NET SDK 9](https://dotnet.microsoft.com/download/dotnet/9.0)
* [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (Express, Developer ou outra edição)

### Instalação

1. Clone o repositório:

    ```sh
    git clone [https://github.com/britors/OpenBaseNETSQLServer.git](https://github.com/britors/OpenBaseNETSQLServer.git)

2. Navegue até a pasta do projeto.

3. Configure sua string de conexão com o banco de dados no arquivo `appsettings.json` dentro do projeto `OpenBaseNET.Presentation.Api`.

4. Execute a migração para criar o banco de dados. No terminal de sua preferência (na raiz do projeto), execute:

    ```sh
    dotnet ef database update --startup-project src/01-Presentation

    *Alternativamente, use o Package Manager Console no Visual Studio com o comando `Update-Database`.*

5. Execute a aplicação:

    ```sh
    dotnet run --project src/01-Presentation
    ```