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
    }
}

