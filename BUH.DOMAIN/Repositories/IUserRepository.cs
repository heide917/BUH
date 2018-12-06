using Bank.Domain.Repositories.Base;
using BUH.Domain.Models;
using BUH.Domain.Repositories.Base;

namespace BUH.Domain.Repositories
{
    public interface IUserRepository : IEntityRepository<User>, IDisposableRepository
    {
    }
}
