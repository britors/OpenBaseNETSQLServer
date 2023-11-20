namespace OpenBaseNET.Infra.Uow.Interfaces;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();

    Task CommitAsync();

    Task RollbackAsync();
}