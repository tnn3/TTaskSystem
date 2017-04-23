using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
namespace Interfaces.UOW
{
    public interface IUOW
    {
        // standard IRepository based repos
        IAttachmentRepository Attachments { get; }
        IChangeRepository Changes { get; }
        IChangeSetRepository ChangeSets { get; }
        ICustomFieldRepository CustomFields { get; }
        ICustomFieldValueRepository CustomFieldValues { get; }
        IPriorityRepository Priorities { get; }
        IProjectRepository Projects { get; }
        IProjectTaskRepository ProjectTasks { get; }
        IStatusRepository Statuses { get; }
        IUserInProjectRepository UserInProjects { get; }
        IUserTitleRepository UserTitles { get; }
        IUserTitleInProjectRepository UserTitleInProjects { get; }
        IStatusInProjectRepository StatusInProjects { get; }


        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        // get standard repository for type TEntity
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;
        TRepository GetCustomRepository<TRepository>() where TRepository : class;
    }
}