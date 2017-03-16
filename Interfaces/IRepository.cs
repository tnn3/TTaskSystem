using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> All { get; }
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        void Remove(TEntity entity);
        int SaveChanges();

    }
}
