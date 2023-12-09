# OpenBaseNET para SQL Server
![image](https://github.com/britors/OpenBase.NET/assets/183213/9d3f3601-d627-4225-b64f-1f4fd0a3f817)



OpenBaseNET para SQL Server é um template para projetos .net 8 usando base de dados SQL Server <br/>
O template foi construído devido a necessidade de criar projetos de forma rápida e prática. <br/>
Para criar um projeto, basta seguir os passos abaixo: <br/>
1) Crie seu projeto usando o template OpenBaseNET <br/>
![image](https://github.com/britors/OpenBaseNETSqlServer/assets/183213/aaade65c-e31e-4dfb-ac4f-2d3e85e2d8a5)


2) Baixe seu projeto para sua máquina <br/>
### Exemplo
```bash
git clone <projeto>
```
3) Dentro da Pasta 01-Presentation, acesse o arquivo appsettings.json e altere a string de conexão para a sua base de dados e para o banco mongodb para logs <br/>
### Exemplo de appsettings
```json
{
  "ConnectionStrings": {
    "OpenBaseSQLServer": "Server=.;Database=OpenBaseNET;Integrated Security=True;TrustServerCertificate=True;",
    "OpenBaseMongoDb": "mongodb://localhost:27017/logs"
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
4) No projeto OpenBaseNET.Application acesse a pasta Entities e crie suas classes para representar as suas entidades (existe um modelo chamado Customer, use como exemplo) <br/>
   É extemamente importante que a classe implemente a interface IEntityOrQueryResult <br/>
### Exemplo de classe para representar uma entidade
```csharp
namespace OpenBaseNET.Domain.Entities;

public sealed class Customer : IEntityOrQueryResult
{
    public int Id { get; set; }
    public Name Name { set; get; } = null!;
 
}
```
5) No Projeto OpenBaseNET.Infra.Data.Context acesse a pasta Configurations e crie a classe de mapeamento da sua entidade (existe um modelo chamado CustomerMapping, use como exemplo) <br/>
### Exemplo de classe para mapear uma entidade
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
A partir de agora você pode criar suas classes de serviço, repositório e controlador para sua entidade <br/>
Caso você siga o padrão de nomenclatura do template não precisará fazer nenhuma configuração adicional <br/>
