﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Interfaces;
using Interfaces.UOW;
namespace DAL.Helpers
{
    public class EFRepositoryFactory : IRepositoryFactory
    {
        private readonly IDictionary<Type, Func<IDataContext, object>> _repositoryFactories;
        public EFRepositoryFactory()
        {
            _repositoryFactories = GetCustomFactories();
        }
        //this ctor is for testing only, you can give here an arbitrary list of repos
        public EFRepositoryFactory(IDictionary<Type, Func<IDataContext, object>> factories)
        {
            _repositoryFactories = factories;
        }
        //special repos with custom interfaces are registered here
        private static IDictionary<Type, Func<IDataContext, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<IDataContext, object>>
            {
                  {typeof(IAttachmentRepository), dbContext => new AttachmentRepository(dbContext)},
                  {typeof(IChangeRepository), dbContext => new ChangeRepository(dbContext)},
                  {typeof(IChangeSetRepository), dbContext => new ChangeSetRepository(dbContext)},
                  {typeof(ICustomFieldRepository), dbContext => new CustomFieldRepository(dbContext)},
                  {typeof(ICustomFieldValueRepository), dbContext => new CustomFieldValueRepository(dbContext)},
                  {typeof(IClientRepository), dbContext => new ClientRepository(dbContext)},
                  {typeof(IUserTitleInProjectRepository), dbContext => new UserTitleInProjectRepository(dbContext)},
                  {typeof(IUserTitleRepository), dbContext => new UserTitleRepository(dbContext)},
                  {typeof(IPriorityRepository), dbContext => new PriorityRepository(dbContext)},
                  {typeof(IProjectRepository), dbContext => new ProjectRepository(dbContext)},
                  {typeof(IProjectTaskRepository), dbContext => new ProjectTaskRepository(dbContext)},
                  {typeof(IStatusRepository), dbContext => new StatusRepository(dbContext)},
            };
        }
        public Func<IDataContext, object> GetRepositoryFactoryForType<T>() where T : class
        {
            return GetCustomRepositoryFactory<T>() ?? GetStandardRepositoryFactory<T>();
        }
        public Func<IDataContext, object> GetCustomRepositoryFactory<T>() where T : class
        {
            Func<IDataContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }
        // return factory (function) for creation of standard repositories
        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {
            // create new instance of EFRepository<TEntity>
            return dataContext => new EFRepository<TEntity>(dataContext);
        }
    }
}