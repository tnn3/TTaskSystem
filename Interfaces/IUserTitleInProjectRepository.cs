using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface IUserTitleInProjectRepository : IRepository<UserTitleInProject>
    {
        Task<List<UserTitleInProject>> AllAsyncWithIncludes();
        Task<UserTitleInProject> FindAsyncWithIncludes(int id);
        Task<List<UserTitleInProject>> AllProjectsAsync(int projectId);
    }
}
