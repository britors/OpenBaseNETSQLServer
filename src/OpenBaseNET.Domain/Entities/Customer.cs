using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.ValueObjects;

namespace OpenBaseNET.Domain.Entities;

public sealed class Customer : IEntityOrQueryResult
{
    public int Id { get; set; }
    public Name Name { set; get; } = null!;
 
}