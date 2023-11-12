using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public class FindCustomerByNameRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Name { get; set; } = string.Empty;
}