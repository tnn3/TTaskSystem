using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class

    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;
        public EFRepository(DbContext dbContext)
        {
            RepositoryDbContext = dbContext;
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
        }

        public List<TEntity> All => RepositoryDbSet.ToList();

        public TEntity Find(int id)
        {
            return RepositoryDbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            RepositoryDbSet.Attach(entity);
        }

        public void Remove(int id)
        {
            var entity = Find(id);
            Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return RepositoryDbContext.SaveChanges();
        }
    }
}
