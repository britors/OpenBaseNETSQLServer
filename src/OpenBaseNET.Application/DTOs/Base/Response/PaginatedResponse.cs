namespace OpenBaseNET.Application.DTOs.Base.Response;

public readonly struct PaginatedResponse<TResult>(
    int currentPage,
    int pageSize,
    int totalRecords,
    int totalPages,
    IEnumerable<TResult> results)
{
    public int CurrentPage { get; } = currentPage;
    public int PageSize { get; } = pageSize;
    public int TotalPages { get; } = totalPages;
    public int TotalRecords { get; } = totalRecords;
    public IEnumerable<TResult> Results { get; } = results;
}