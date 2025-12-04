/*
 * Name: PaginatedResponse
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: DTO Struct
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Extrutura para retornar objetos paginados
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação da Extrutura                        |
 * |--------------------------------------------------------------|
 */


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