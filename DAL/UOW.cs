using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Identity;
using Interfaces;
using Interfaces.UOW;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UOW<TContext> : IUOW where TContext : IDataContext
    {
        private DbContext _context;
        private readonly IRepositoryProvider _repositoryProvider;

        public IRepository<ApplicationUser> People => GetEntityRepository<ApplicationUser>();
        public IAttachmentRepository Attachments => GetCustomRepository<IAttachmentRepository>();
        public IChangeRepository Changes => GetCustomRepository<IChangeRepository>();
        public IChangeSetRepository ChangeSets => GetCustomRepository<IChangeSetRepository>();
        public ICustomFieldRepository CustomFields => GetCustomRepository<ICustomFieldRepository>();
        public ICustomFieldValueRepository CustomFieldValues => GetCustomRepository<ICustomFieldValueRepository>();
        public IPriorityRepository Priorities => GetCustomRepository<IPriorityRepository>();
        public IProjectRepository Projects => GetCustomRepository<IProjectRepository>();
        public IProjectTaskRepository ProjectTasks => GetCustomRepository<IProjectTaskRepository>();
        public IStatusRepository Statuses => GetCustomRepository<IStatusRepository>();
        public IUserInProject UserInProjects => GetCustomRepository<IUserInProject>();
        public IUserTitleRepository UserTitles => GetCustomRepository<IUserTitleRepository>();
        public IUserTitleInProjectRepository UserTitleInProjects => GetCustomRepository<IUserTitleInProjectRepository>();
        public IStatusInProjectRepository StatusInProjects => GetCustomRepository<IStatusInProjectRepository>();

        public UOW(TContext context, IRepositoryProvider repositoryProvider)
        {
            _context = (context as DbContext) ?? throw new NullReferenceException(nameof(context));
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
            return _context.SaveChangesAsync(cancellationToken);
        }

        #region IDisposable Implementation
        private bool _isDisposed;
        protected void CheckDisposed()
        {
            if (_isDisposed) throw new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~UOW()
        {
            Dispose(false);
        }
        #endregion
    }
}
