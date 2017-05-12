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
    public class StatusInProjectRepository : EFRepository<StatusInProject>, IStatusInProjectRepository
    {
        public StatusInProjectRepository(IDataContext dbContext) : base(dbContext)
        {
            
        }

        public Task<List<StatusInProject>> AllAsyncWithIncludes()
        {
            return RepositoryDbSet
                .Include(s => s.Project)
                .Include(s => s.Status)
                .ToListAsync();
        }

        public Task<StatusInProject> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet
                .Include(s => s.Project)
                .Include(s => s.Status)
                .SingleOrDefaultAsync(m => m.StatusInProjectId == id);
        }

        public Task<List<StatusInProject>> GetProjectStatuses(int projectId)
        {
            return RepositoryDbSet
                .Include(s => s.Project)
                .Include(s => s.Status)
                .Where(s => s.ProjectId == projectId).ToListAsync();
        }
    }
}
