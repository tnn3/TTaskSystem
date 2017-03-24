using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Interfaces;
using Interfaces.UOW;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UOW<TContext> : IUOW where TContext : IDataContext
    {
        private DbContext _context;
        private readonly IRepositoryProvider _repositoryProvider;
        public IRepository<Person> People => GetEntityRepository<Person>();
        public UOW(TContext context, IRepositoryProvider repositoryProvider)
        {
            _context = (context as DbContext) ?? throw new NullReferenceException(message: nameof(context));
            _repositoryProvider = repositoryProvider;
        }

        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            CheckDisposed();
            return _repositoryProvider.GetEntityRepository<TEntity>();
        }
        // get custom repository by interface
        public TRepository GetCustomRepository<TRepository>() where TRepository : class
        {
            CheckDisposed();
            return _repositoryProvider.GetCustomRepository<TRepository>();
        }

        public int SaveChanges()
        {
            CheckDisposed();
            return _context.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            CheckDisposed();
            return _context.SaveChangesAsync();
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            CheckDisposed();
            return _context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        #region IDisposable Implementation
        private bool _isDisposed;
        protected void CheckDisposed()
        {
            if (_isDisposed) throw new ObjectDisposedException(objectName: "The UnitOfWork is already disposed and cannot be used anymore.");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }
            }
            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(obj: this);
        }
        ~UOW()
        {
            Dispose(disposing: false);
        }
        #endregion

        /*private readonly IDataContext _dataContext;
        private readonly IRepositoryProvider _repositoryProvider;

        public Uow(IDataContext dataContext, IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));

        }

        public int SaveChanges()
        {
            return ((AppDbContext) _dataContext).SaveChanges();
        }

        public IPriorityRepository Priorities => GetCustomRepository<IPriorityRepository>();
        public IRepository<Status> Statuses => GetStandardRepository<Status>();

        private TaskRepository GetCustomRepository<TRepository>()
        {
            return _repositoryProvider.GetCustomRepository<TRepository>();
        }

        private IRepository<TEntity> GetStandardRepository<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetStandardRepository<IRepository<TEntity>>();
        }*/
    }
}
