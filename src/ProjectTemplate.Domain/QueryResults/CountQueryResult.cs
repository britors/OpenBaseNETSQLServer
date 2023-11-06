using ProjectTemplate.Domain.Interfaces.Repositories;

namespace ProjectTemplate.Domain.QueryResults
{
    public readonly struct CountQueryResult : IEntityOrQueryResult
    {
        public int Total { get; }

        public CountQueryResult(int total)
        {
            Total = total;
        }
    }
}
