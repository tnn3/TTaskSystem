using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<TEntity>
    {
        //List<TEntity> All { get; }
        IEnumerable<TEntity> All();
        //TEntity Find(int id);
        Task<IEnumerable<TEntity>> AllAsync();
        TEntity Find(params object[] id);
        Task<TEntity> FindAsync(params object[] id);
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        //void Update(TEntity entity);
        TEntity Update(TEntity entity);
        //void Remove(int id);
        void Remove(TEntity entity);
        void Remove(params object[] id);
        //int SaveChanges();

    }
}
