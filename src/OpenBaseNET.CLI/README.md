# OpenBaseNET SQL Server CLI 🚀

A **OpenBaseNET CLI** é a interface oficial de linha de comando desenvolvida para acelerar a criação de APIs robustas utilizando o template **OpenBaseNET SQL Server**.

Com esta ferramenta, você pula a configuração repetitiva de arquitetura e foca no desenvolvimento das suas regras de negócio.

[![NuGet Version](https://img.shields.io/nuget/v/w3ti.OpenBaseNETSqlServer.Cli.svg)](https://www.nuget.org/packages/w3ti.OpenBaseNETSqlServer.Cli)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.txt)
[![.NET 10](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/10.0)

---

## 🌟 Vantagens

Esta CLI garante que seu projeto comece com as melhores práticas de mercado:

* **Clean Architecture:** Separação clara entre Domínio, Aplicação e Infraestrutura.
* **Repository Pattern:** Abstração de dados utilizando EF Core e Dapper.
* **Resiliência:** Estratégias de retry nativas para SQL Server.
* **Modernidade:** Totalmente otimizado para **.NET 10**.

---

## 🛠 Instalação

A CLI é instalada como uma ferramenta global do .NET. Execute o comando abaixo:

```bash
dotnet tool install -g w3ti.OpenBaseNETSqlServer.Cli

Dica: Caso já possua uma versão instalada, utilize o comando update:

dotnet tool update -g w3ti.OpenBaseNETSqlServer.Cli

🚀 Comandos Disponíveis
1. Instalar Template
Configura o ambiente com o template de projeto oficial.

Bash
openbase install
2. Criar Novo Projeto
Gera uma nova Web API com todas as camadas da solução configuradas.

Bash
openbase new NomeDoMeuProjeto
3. Atualizar
Atualiza simultaneamente a própria CLI e os templates registrados.

Bash
openbase update
🏗 Camadas Geradas
Ao criar um projeto, a solução é estruturada da seguinte forma:

Domain: Entidades e interfaces de contrato.

Application: Serviços, DTOs e mapeamentos.

Infra.Data: Contexto do banco de dados e repositórios.

Presentation.Api: Web API com Swagger, Logging e DI prontos.

📅 Próximos Passos (Roadmap)
[ ] Scaffolding: Comando openbase add <Entity> para gerar CRUD completo.

[ ] Injeção de Dependência Automática.

[ ] Suporte a PostgreSQL.

📄 Licença
Distribuído sob a licença MIT. Veja o arquivo LICENSE.txt para detalhes.

Desenvolvido por Rodrigo Brito (w3ti)
