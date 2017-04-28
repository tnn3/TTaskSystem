using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserInProjectRepository : EFRepository<UserInProject>, IUserInProjectRepository
    {
        public UserInProjectRepository(IDataContext dataContext) : base(dataContext)
        {

        }

        public Task<List<UserInProject>> AllAsyncWithIncludes()
        {
            return RepositoryDbSet.Include(u => u.Project).Include(u => u.TitleInProject).ToListAsync();
        }

        public Task<UserInProject> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet.Include(u => u.Project).Include(u => u.TitleInProject).SingleOrDefaultAsync(m => m.UserInProjectId == id);
        }
    }
}
