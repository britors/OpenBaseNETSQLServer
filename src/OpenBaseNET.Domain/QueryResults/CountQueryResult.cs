using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.QueryResults;

public readonly struct CountQueryResult : IEntityOrQueryResult
{
    public int Total { get; }

    public CountQueryResult(int total)
    {
        Total = total;
    }
}