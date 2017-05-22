using System;
using System.Collections.Generic;
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

        public Task<Project> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet
                .Include(s => s.CustomFields)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
        }
    }
}

