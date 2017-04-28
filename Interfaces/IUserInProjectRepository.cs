using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces
{
    public interface IUserInProjectRepository : IRepository<UserInProject>
    {
        Task<List<UserInProject>> AllAsyncWithIncludes();
        Task<UserInProject> FindAsyncWithIncludes(int id);
    }
}
