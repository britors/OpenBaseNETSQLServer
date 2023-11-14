using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public class GetCustomerRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required int Page { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required int PageSize { get; set; }
}