using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        // the context and the dbset we are working with
        protected DbContext RepositoryDbContext { get; set; }
        protected DbSet<TEntity> RepositoryDbSet { get; set; }

        //Constructor, requires dbContext as dependency
        public EFRepository(IDataContext dataContext)
        {
            RepositoryDbContext = dataContext as DbContext ?? throw new ArgumentNullException(nameof(dataContext));
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>() ?? throw new NullReferenceException($"DbSet for {nameof(TEntity)} not found!");
        }

        public IEnumerable<TEntity> All() => RepositoryDbSet.ToList();

        public async Task<IEnumerable<TEntity>> AllAsync() => await RepositoryDbSet.ToListAsync();

        public TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(id);
        }

        public Task<TEntity> FindAsync(params object[] id)
        {
            return RepositoryDbSet.FindAsync(id);
        }
        public async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await RepositoryDbSet.FindAsync(keyValues, cancellationToken);
        }
        public void Add(TEntity entity)
        {
            if (entity == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");
            RepositoryDbSet.Add(entity);
        }
        public async Task AddAsync(TEntity entity)
        {
            if (entity == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");
            await RepositoryDbSet.AddAsync(entity);
        }
        public TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }
        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Attach(entity);
            RepositoryDbContext.Entry(entity).State = EntityState.Deleted;
            RepositoryDbSet.Remove(entity);
        }
        public void Remove(params object[] id)
        {
            Remove(Find(id));
        }
    }
}