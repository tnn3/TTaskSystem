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
    public class ProjectRepository : EFRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IDataContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Project>> AllUserProjectsAsync(int userId)
        {
            return RepositoryDbSet
                .Include(p => p.CustomFields)
                .Include(p => p.UsersInProject)
                .Where(p => p.UsersInProject.Any(o => o.UserId == userId))
                .ToListAsync();
        }

        public Task<Project> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet
                .Include(s => s.CustomFields)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
        }

        public Task<Project> FindUserProjectAsync(int projectId, int userId)
        {
            return RepositoryDbSet
                .Include(p => p.CustomFields)
                .Include(p => p.UsersInProject)
                .SingleOrDefaultAsync(m => m.ProjectId == projectId && m.UsersInProject.Any(o => o.UserId == userId));
        }

        public bool Exists(int projectId)
        {
            return RepositoryDbSet.Find(projectId) != null;
        }
    }
}

