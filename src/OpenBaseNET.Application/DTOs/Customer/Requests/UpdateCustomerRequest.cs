using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public class UpdateCustomerRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required string Name { get; set; }
}