using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Application.DTOs.Cliente;
public class BuscaClienteRequest
{
    [Required]
    public required string Nome { get; set; }
}
