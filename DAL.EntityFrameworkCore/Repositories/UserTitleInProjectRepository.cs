using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class UserTitleInProjectRepository : EFRepository<UserTitleInProject>, IUserTitleInProjectRepository
    {
        public UserTitleInProjectRepository(IDataContext dbContext) : base(dbContext)
        {

        }

        public Task<List<UserTitleInProject>> AllAsyncWithIncludes()
        {
            return RepositoryDbSet.Include(u => u.Project).Include(u => u.Title).ToListAsync();
        }

        public Task<UserTitleInProject> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet.Include(u => u.Project).Include(u => u.Title).SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);
        }
    }
}

