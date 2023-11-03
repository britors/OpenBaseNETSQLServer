using ProjectTemplate.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities;

[Table("CLITAB")]
public sealed class Cliente : IEntityOrQueryResult
{
    [Key]
    [Column("CLIID")]
    public int Id { get; set; }

    [Required]
    [Column("CLINM")]
    public string Nome { set; get; } = string.Empty;
}