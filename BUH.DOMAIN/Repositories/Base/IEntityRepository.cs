using System.Collections.Generic;

namespace BUH.Domain.Repositories.Base
{
    public interface IEntityRepository<T>
    {
        IEnumerable<T> GetCollection();

        T GetById(int id);

        int Insert(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
