using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.Entities;

[Table("CLITAB")]
public sealed class Cliente : IEntityOrQueryResult
{
    [Key] [Column("CLIID")] public int Id { get; set; }

    [Required] [Column("CLINM")] public string Nome { set; get; } = string.Empty;
}