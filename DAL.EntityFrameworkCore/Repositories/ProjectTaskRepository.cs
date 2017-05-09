using System;
using System.Collections.Generic;
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
                .ToListAsync();
        }
    }
}

