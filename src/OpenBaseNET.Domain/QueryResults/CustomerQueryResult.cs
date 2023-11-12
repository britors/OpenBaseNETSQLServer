using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.QueryResults;

public readonly struct CustomerQueryResult : IEntityOrQueryResult
{
    public int Id { get; }
    public string Name { get; }

    public CustomerQueryResult(int id, string name)
    {
        Id = id;
        Name = name;
    }
}