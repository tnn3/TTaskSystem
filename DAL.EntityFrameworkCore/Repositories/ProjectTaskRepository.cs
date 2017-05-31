using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class ProjectTaskRepository : EFRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(IDataContext dbContext) : base(dbContext)
        {

        }

        public Task<List<ProjectTask>> AllAsyncWithIncludes()
        {
            return RepositoryDbSet
                .Include(p => p.Project)
                .Include(p => p.Status.Status)
                .Include(p => p.Priority)
                .Include(p => p.AssignedTo)
                .ToListAsync();
        }

        public Task<List<ProjectTask>> AllInProject(int projectId)
        {
            return RepositoryDbSet
                .Include(p => p.Project)
                .Include(p => p.Status.Status)
                .Include(p => p.Priority)
                .Include(p => p.AssignedTo)
                .Where(p => p.Project.ProjectId == projectId)
                .ToListAsync();
        }

        public Task<List<ProjectTask>> AllInProjectWithUser(int projectId, int userId)
        {
            return RepositoryDbSet
                .Include(p => p.Project)
                .Include(p => p.Project.UsersInProject)
                .Include(p => p.Status.Status)
                .Include(p => p.Priority)
                .Include(p => p.AssignedTo)
                .Where(p => p.ProjectId == projectId && p.Project.UsersInProject.Any(o => o.UserId == userId))
                .ToListAsync();
        }

        public Task<ProjectTask> FindAsyncWithIncludesAndUser(int taskId, int userId)
        {
            return RepositoryDbSet
                .Include(p => p.Project)
                .Include(p => p.Project.UsersInProject)
                .Include(p => p.CustomFieldValue)
                .Include(p => p.Attachments)
                .Where(p => p.Project.UsersInProject.Any(o => o.UserId == userId && o.ProjectId == p.ProjectId))
                .SingleOrDefaultAsync(m => m.ProjectTaskId == taskId);
        }

        public Task<ProjectTask> FindWithUserAsync(int taskId, int userId)
        {
            return RepositoryDbSet
                .Include(p => p.Project)
                .Include(p => p.Project.UsersInProject)
                .Where(p => p.Project.UsersInProject.Any(o => o.UserId == userId && o.ProjectId == p.ProjectId))
                .SingleOrDefaultAsync(p => p.ProjectTaskId == taskId);
        }
    }
}

