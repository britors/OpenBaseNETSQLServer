using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Application.DTOs.Cliente.Requests;

public class TodosOsClientesRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Page { get; set; }

    [Required(ErrorMessage = "O campo {1} é obrigatório.")]
    public int PageSize { get; set; }
}