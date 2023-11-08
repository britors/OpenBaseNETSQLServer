namespace ProjectTemplate.Application.DTOs.Base.Response;

public class PaginatedResponse<TResult>
{
    public PaginatedResponse(int currentPage,
        int pageSize,
        int totalRecords,
        int totalPages,
        IEnumerable<TResult> results)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalPages = totalPages;
        TotalRecords = totalRecords;
        Results = results;
    }

    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalRecords { get; }
    public IEnumerable<TResult> Results { get; }
}