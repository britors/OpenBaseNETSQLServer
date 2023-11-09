using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Application.DTOs.Cliente.Requests;

public class AtualizarClienteRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; } = string.Empty;
}