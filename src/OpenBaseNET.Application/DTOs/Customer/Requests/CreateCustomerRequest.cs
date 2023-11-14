using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public class CreateCustomerRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required string Name { get; set; }
}