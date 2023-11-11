﻿using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Cliente.Requests;

public class BuscaClientePorNomeRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; } = string.Empty;
}