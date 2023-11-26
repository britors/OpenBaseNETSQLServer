namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public sealed record GetCustomerRequest(string Name = "", int Page = 1, int PageSize = 5);