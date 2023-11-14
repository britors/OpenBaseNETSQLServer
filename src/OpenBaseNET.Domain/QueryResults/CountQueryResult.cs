using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.QueryResults;

public readonly struct CountQueryResult(int total) : IEntityOrQueryResult
{
    public int Total { get; } = total;
}