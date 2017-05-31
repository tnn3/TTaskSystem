using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface IProjectTaskRepository : IRepository<ProjectTask>
    {
        Task<List<ProjectTask>> AllAsyncWithIncludes();
        Task<List<ProjectTask>> AllInProject(int projectId);
        Task<List<ProjectTask>> AllInProjectWithUser(int projectId, int userId);
        Task<ProjectTask> FindAsyncWithIncludesAndUser(int taskId, int userId);
        Task<ProjectTask> FindWithUserAsync(int taskId, int userId);
        Task<ProjectTask> FindWithIncludesAsync(int taskId);
    }
}
