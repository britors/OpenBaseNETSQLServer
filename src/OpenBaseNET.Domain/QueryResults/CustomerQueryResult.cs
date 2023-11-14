using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.QueryResults;

public readonly struct CustomerQueryResult(int id, string name) : IEntityOrQueryResult
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}