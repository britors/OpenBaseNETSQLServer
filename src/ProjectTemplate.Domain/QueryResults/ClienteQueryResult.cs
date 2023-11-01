using ProjectTemplate.Domain.Interfaces;

namespace ProjectTemplate.Domain.QueryResults;

public readonly struct ClienteQueryResult : IEntityOrQueryResult
{
    public int Id { get; }
    public string Name { get; }

    public ClienteQueryResult(int id, string nome)
    {
        Id = id;
        Name = nome;
    }
}