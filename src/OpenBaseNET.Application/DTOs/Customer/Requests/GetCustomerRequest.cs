using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public class GetCustomerRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Page { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int PageSize { get; set; }
}