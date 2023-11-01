using ProjectTemplate.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities;

[Table("CLITAB")]
public class Cliente : IEntityOrQueryResult
{
    [Key]
    [Column("CLIID")]
    public int Id { get; set; }

    [Required]
    [Column("CLINM")]
    public required string Name { set; get; }
}