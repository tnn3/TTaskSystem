using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces
{
    public interface IUserTitleInProjectRepository : IRepository<UserTitleInProject>
    {
        Task<List<UserTitleInProject>> AllAsyncWithIncludes();
        Task<UserTitleInProject> FindAsyncWithIncludes(int id);
    }
}
