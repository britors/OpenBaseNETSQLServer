using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Infra.Data.Context;

namespace OpenBaseNET.Infra.Data.Repositories;

public sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository, IDataRepository
{
    public CustomerRepository(DbSession dbSession,
        OneBaseDataBaseContext context) :
        base(dbSession, context)
    {
    }
}