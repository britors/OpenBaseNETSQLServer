using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Customer.Requests;

public class FindCustomerByIdRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public required int Id { get; set; }
}