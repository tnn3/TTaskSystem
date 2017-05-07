﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore.Identity.Uow.Interfaces;
using DAL.Helpers;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFrameworkCore
{
    public class ApplicationUnitOfWork<TContext> : IApplicationUnitOfWork
        where TContext : IDataContext
    {
        #region Identity repositories
        public IIdentityRoleClaimRepository IdentityRoleClaims => GetCustomRepository<IIdentityRoleClaimRepository>();
        public IIdentityRoleRepository IdentityRoles => GetCustomRepository<IIdentityRoleRepository>();
        public IIdentityUserClaimRepository IdentityUserClaims => GetCustomRepository<IIdentityUserClaimRepository>();
        public IIdentityUserLoginRepository IdentityUserLogins => GetCustomRepository<IIdentityUserLoginRepository>();
        public IIdentityUserRepository<ApplicationUser> IdentityUsers => GetCustomRepository<IIdentityUserRepository<ApplicationUser>>();
        public IIdentityUserRoleRepository IdentityUserRoles => GetCustomRepository<IIdentityUserRoleRepository>();
        public IIdentityUserTokenRepository IdentityUserTokens => GetCustomRepository<IIdentityUserTokenRepository>();
        #endregion

        #region Custom repositories
        public IApplicationUserRepository ApplicationUsers => GetCustomRepository<IApplicationUserRepository>();
        public IAttachmentRepository Attachments => GetCustomRepository<IAttachmentRepository>();
        public IChangeRepository Changes => GetCustomRepository<IChangeRepository>();
        public IChangeSetRepository ChangeSets => GetCustomRepository<IChangeSetRepository>();
        public ICustomFieldRepository CustomFields => GetCustomRepository<ICustomFieldRepository>();
        public ICustomFieldValueRepository CustomFieldValues => GetCustomRepository<ICustomFieldValueRepository>();
        public IPriorityRepository Priorities => GetCustomRepository<IPriorityRepository>();
        public IProjectRepository Projects => GetCustomRepository<IProjectRepository>();
        public IProjectTaskRepository ProjectTasks => GetCustomRepository<IProjectTaskRepository>();
        public IStatusRepository Statuses => GetCustomRepository<IStatusRepository>();
        public IUserInProjectRepository UserInProjects => GetCustomRepository<IUserInProjectRepository>();
        public IUserTitleRepository UserTitles => GetCustomRepository<IUserTitleRepository>();
        public IUserTitleInProjectRepository UserTitleInProjects => GetCustomRepository<IUserTitleInProjectRepository>();
        public IStatusInProjectRepository StatusInProjects => GetCustomRepository<IStatusInProjectRepository>();
        #endregion

        private DbContext _context;
        private readonly IRepositoryProvider _repositoryProvider;

        public ApplicationUnitOfWork(TContext context, IRepositoryProvider repositoryProvider)
        {
            _context = (context as DbContext) ?? throw new NullReferenceException(message: nameof(context));
            _repositoryProvider = repositoryProvider ?? throw new NullReferenceException(message: nameof(repositoryProvider));
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

        // get standard repository for entity 
        public DAL.Repositories.IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
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

        ~ApplicationUnitOfWork()
        {
            Dispose(disposing: false);
        }

        #endregion
    }
}
