using ProjectTemplate.Domain.Interfaces.Repositories;

namespace ProjectTemplate.Domain.QueryResults;

public readonly struct PaginationQueryResult<TResult> where TResult : IEntityOrQueryResult
{
    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalRecords { get; }
    public IEnumerable<TResult> Results { get; }

    public PaginationQueryResult(int currentPage,
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