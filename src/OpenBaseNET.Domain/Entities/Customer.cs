using OpenBaseNET.Domain.Interfaces.Repositories;

namespace OpenBaseNET.Domain.Entities;

public sealed class Customer : IEntityOrQueryResult
{
    public int Id { get; set; }
    public string Name { set; get; } = string.Empty;
}