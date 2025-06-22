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

## Para criar um projeto, basta seguir os passos abaixo:

#### Crie seu projeto usando o template OpenBaseNET <br/>
![image](https://github.com/britors/OpenBaseNETSqlServer/assets/183213/aaade65c-e31e-4dfb-ac4f-2d3e85e2d8a5)


#### Baixe seu projeto para sua máquina <br/>
```bash
git clone <projeto>
```
#### Dentro da Pasta _01-Presentation_, acesse o arquivo appsettings.json e altere a string de conexão para a sua base de dados <br/>
```json
{
  "ConnectionStrings": {
    "OpenBaseSQLServer": "Server=.;Database=OpenBaseNET;Integrated Security=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
#### No projeto OpenBaseNET.Application acesse a pasta Entities e crie suas classes para representar as suas entidades (existe um modelo chamado Customer, use como exemplo) <br/>
   É extemamente importante que a classe implemente a interface _IEntityOrQueryResult_ <br/>
```csharp
namespace OpenBaseNET.Domain.Entities;

public sealed class Customer : IEntityOrQueryResult
{
    public int Id { get; set; }
    public Name Name { set; get; } = null!;
 
}
```
#### No Projeto OpenBaseNET.Infra.Data.Context acesse a pasta Configurations e crie a classe de mapeamento da sua entidade (existe um modelo chamado CustomerMapping, use como exemplo) <br/>
```csharp
namespace OpenBaseNET.Infra.Data.Context.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("CLITAB");

        builder.HasKey(c => c.Id)
            .HasName("PK_CLITAB");

        builder
            .Property(c => c.Id)
            .HasColumnName("CLIID");
        
        builder
            .OwnsOne(
                c => c.Name, 
                name =>
            {
                    name.Property(n => n.Value)
                    .HasColumnName("CLINM")
                    .HasMaxLength(255)
                    .IsRequired();
            });
    }
}
```

# Pronto!
>A partir de agora você pode criar suas classes de serviço, repositório e controlador para sua entidade <br/>
Caso você siga o padrão de nomenclatura do template não precisará fazer nenhuma configuração adicional <br/>
