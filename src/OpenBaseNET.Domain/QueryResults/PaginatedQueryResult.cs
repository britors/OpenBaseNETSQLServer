using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.QueryResults;

public readonly struct PaginatedQueryResult<TResult>(
    int currentPage,
    int pageSize,
    int totalRecords,
    IEnumerable<TResult> results)
    where TResult : IEntityOrQueryResult
{
    public int CurrentPage { get; } = currentPage;
    public int PageSize { get; } = pageSize;
    public int TotalPages { get; } = (int)Math.Ceiling((double)totalRecords / pageSize);
    public int TotalRecords { get; } = totalRecords;
    public IEnumerable<TResult> Results { get; } = results;
}