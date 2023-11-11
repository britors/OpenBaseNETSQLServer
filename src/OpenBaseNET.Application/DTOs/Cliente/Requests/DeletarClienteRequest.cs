using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Cliente.Requests;

public class DeletarClienteRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Id { get; set; }
}