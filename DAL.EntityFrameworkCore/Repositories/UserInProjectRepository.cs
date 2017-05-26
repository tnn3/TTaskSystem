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
    public class UserInProjectRepository : EFRepository<UserInProject>, IUserInProjectRepository
    {
        public UserInProjectRepository(IDataContext dataContext) : base(dataContext)
        {

        }

        public Task<List<UserInProject>> AllAsyncWithIncludes()
        {
            return RepositoryDbSet
                .Include(u => u.Project)
                .Include(u => u.TitleInProject.Title)
                .Include(u => u.User)
                .ToListAsync();
        }

        public Task<UserInProject> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet
                .Include(u => u.Project)
                .Include(u => u.TitleInProject.Title)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.UserInProjectId == id);
        }

        public Task<List<UserInProject>> AllInProject(int projectId)
        {
            return RepositoryDbSet
                .Include(u => u.Project)
                .Include(u => u.TitleInProject.Title)
                .Include(u => u.User)
                .Where(u => u.ProjectId == projectId)
                .ToListAsync();
        }
    }
}
