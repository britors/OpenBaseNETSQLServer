// ReSharper disable NotAccessedPositionalProperty.Global
namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public sealed record GetCustomerRequest(int Page, int PageSize)
{
    // ReSharper disable once UnusedMember.Global
    public string Name { get; init; } = string.Empty;
}