﻿using System.ComponentModel.DataAnnotations;

namespace OpenBaseNET.Application.DTOs.Cliente.Requests;

public class CadastrarClienteRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; } = string.Empty;
}