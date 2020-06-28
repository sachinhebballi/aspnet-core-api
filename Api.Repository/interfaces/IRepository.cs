using System.Collections.Generic;

namespace Api.Repository.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IEnumerable<TEntity> GetAll(int pageNumber, int pageSize);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
