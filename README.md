# OpenBaseNET SQLServer Template

![GitHub repo size](https://img.shields.io/github/repo-size/britors/OpenBaseNETSqlServer)
![NuGet Version](https://img.shields.io/nuget/v/w3ti.OpenBaseNET.SQLServer.Template.svg)
![GitHub language count](https://img.shields.io/github/languages/count/britors/OpenBaseNETSqlServer)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

> OpenBaseNET para SQL Server é um template para projetos .net 9 usando base de dados Microsoft SQL Server.

O template foi construído devido a necessidade de criar projetos  forma rápida e prática.

Um template de projeto .NET para acelerar o desenvolvimento de APIs, já configurado com Arquitetura Limpa, Entity Framework Core e SQL Server.

## Sobre o Projeto

Iniciar um novo projeto exige muita configuração repetitiva: estruturar as pastas, definir as camadas da aplicação, configurar o acesso a dados, etc.

Este template foi criado para eliminar essa etapa inicial. Com um único comando, você terá uma solução .NET completa e robusta, pronta para você focar no que realmente importa: as regras de negócio da sua aplicação.

## 🏛️ Estrutura da Arquitetura

O template utiliza os princípios da Clean Architecture para separar as responsabilidades de forma clara, garantindo um código organizado, testável e de fácil manutenção.

* **MinhaNovaApi.Domain:** A camada mais interna e o coração da aplicação. Contém as entidades de negócio, enums e as interfaces dos repositórios. Não depende de nenhuma outra camada.

* **MinhaNovaApi.Application:** Contém a lógica de negócio e os casos de uso (também conhecidos como "interactors"). Orquestra o fluxo de dados entre a apresentação e a infraestrutura, mas não conhece os detalhes de implementação de nenhum deles.

* **MinhaNovaApi.Infrastructure:** Implementa as abstrações definidas nas camadas internas. É aqui que reside o `DbContext` do Entity Framework, a implementação concreta dos repositórios e a integração com quaisquer outros serviços externos (como gateways de pagamento, envio de e-mails, etc.).

* **MinhaNovaApi.API (Presentation):** A camada de entrada e saída. Contém os Controllers da API, DTOs (Data Transfer Objects) e a configuração da inicialização do serviço (`Program.cs`). É a única camada que o usuário final "vê".

### Tecnologias Principais

* **.NET 9**
* **Entity Framework Core 9**
* **Arquitetura Limpa (Clean Architecture)**
* **Padrão de Repositório (Repository Pattern)**
* **Pronto para SQL Server**

---

## 🚀 Como Usar

Para criar um novo projeto a partir deste template, siga os passos abaixo.

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (versão 9.0 ou superior).

### 1. Instalação do Template

Abra seu terminal ou prompt de comando e execute o seguinte comando para instalar o template a partir do NuGet.org:

```bash
dotnet new install w3ti.OpenBaseNET.SQLServer.Template
```

### 2. Criando um Novo Projeto

Abra seu terminal ou prompt, crie a pasta do projeto e execute o seguinte comando :

```bash
mkdir MinhaNovaApi
cd MinhaNovaApi
dotnet new openbasenet-sql -n MinhaNovaApi
````

### 3. Rodando o Projeto Gerado

  Rode o projeto e a API estará pronta para uso.
  
  ```bash
  dotnet run
  ```

### 4. Modelo a ser seguido

O Projeto vem com um exemplo que representa uma classe que mapeia uma entidade chamada cliente.

Não é necessaria para rodar seu projeto, serve apenas como Guia e pode ser excluida sem problemas

## Agradecimentos

Grato a você que se interessou pelo meu projeto

Feedbacks são sempre bem vindos

Rodrigo S. Brito <rodrigo@w3ti.com.br>
