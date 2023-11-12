using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.QueryResults;

public readonly struct PaginateQueryResult<TResult> where TResult : IEntityOrQueryResult
{
    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalRecords { get; }
    public IEnumerable<TResult> Results { get; }

    public PaginateQueryResult(int currentPage,
        int pageSize,
        int totalRecords,
        IEnumerable<TResult> results)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        TotalRecords = totalRecords;
        Results = results;
    }
}