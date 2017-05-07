using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.Uow.Interfaces;
using DAL.Repositories;
using Domain;
using DAL;

namespace Interfaces
{
    public interface IApplicationUnitOfWork : IUnitOfWork, IIdentityUnitOfWork<ApplicationUser>
    {
        IApplicationUserRepository ApplicationUsers { get; }

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

    }
}
