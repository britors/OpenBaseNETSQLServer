﻿using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Application.DTOs.Cliente.Requests;

public class BuscaClienteRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Id { get; set; }
}