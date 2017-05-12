using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.Uow.Interfaces;
using AspNetCore.Identity.Uow.Models;
using DAL.EntityFrameworkCore.Repositories;
using DAL.Helpers;
using Domain;
using Interfaces;


namespace DAL.EntityFrameworkCore.Helpers
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
                // "No factory for repository type AspNetCore.Identity.Uow.Interfaces.IIdentityRoleRepository`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e],[AspNetCore.Identity.Uow.Models.IdentityRole, AspNetCore.Identity.Uow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]"
                {typeof(IIdentityRoleClaimRepository), dbContext => new IdentityRoleClaimRepository(dataContext: dbContext)},
                {typeof(IIdentityRoleRepository), dbContext => new IdentityRoleRepository(dataContext: dbContext)},
                {typeof(IIdentityUserClaimRepository), dbContext => new IdentityUserClaimRepository(dataContext: dbContext)},
                {typeof(IIdentityUserLoginRepository), dbContext => new IdentityUserLoginRepository(dataContext: dbContext)},
                {typeof(IIdentityUserRepository<ApplicationUser>), dbContext => new IdentityUserRepository<ApplicationUser>(dataContext: dbContext)},
                {typeof(IIdentityUserRoleRepository), dbContext => new IdentityUserRoleRepository(dataContext: dbContext)},
                {typeof(IIdentityUserTokenRepository), dbContext => new IdentityUserTokenRepository(dataContext: dbContext)},

                {typeof(IApplicationUserRepository), dbContext => new ApplicationUserRepository(dbContext)},
                {typeof(IAttachmentRepository), dbContext => new AttachmentRepository(dbContext)},
                {typeof(IChangeRepository), dbContext => new ChangeRepository(dbContext)},
                {typeof(IChangeSetRepository), dbContext => new ChangeSetRepository(dbContext)},
                {typeof(ICustomFieldRepository), dbContext => new CustomFieldRepository(dbContext)},
                {typeof(ICustomFieldValueRepository), dbContext => new CustomFieldValueRepository(dbContext)},
                {typeof(IUserTitleInProjectRepository), dbContext => new UserTitleInProjectRepository(dbContext)},
                {typeof(IUserTitleRepository), dbContext => new UserTitleRepository(dbContext)},
                {typeof(IPriorityRepository), dbContext => new PriorityRepository(dbContext)},
                {typeof(IProjectRepository), dbContext => new ProjectRepository(dbContext)},
                {typeof(IProjectTaskRepository), dbContext => new ProjectTaskRepository(dbContext)},
                {typeof(IStatusRepository), dbContext => new StatusRepository(dbContext)},
                {typeof(IUserInProjectRepository), dbContext => new UserInProjectRepository(dbContext)},
                {typeof(IStatusInProjectRepository), dbContext => new StatusInProjectRepository(dbContext)}

            };
        }

        public Func<IDataContext, object> GetRepositoryFactoryForType<T>() where T : class
        {
            return GetCustomRepositoryFactory<T>() ?? GetStandardRepositoryFactory<T>();
        }

        public Func<IDataContext, object> GetCustomRepositoryFactory<T>() where T : class
        {

            Func<IDataContext, object> factory;

            _repositoryFactories.TryGetValue(key: typeof(T), value: out factory);

            return factory;
        }



        // return factory (function) for creation of standard repositories
        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {
            // create new instance of EFRepository<TEntity>
            return dataContext => new EFRepository<TEntity>(dataContext: dataContext);
        }
    }
}
