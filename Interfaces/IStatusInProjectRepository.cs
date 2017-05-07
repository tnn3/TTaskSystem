using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface IStatusInProjectRepository : IRepository<StatusInProject>
    {
        Task<List<StatusInProject>> AllAsyncWithIncludes();
        Task<StatusInProject> FindAsyncWithIncludes(int id);
    }
}
