using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> FindAsyncWithIncludes(int id);
        Task<List<Project>> AllUserProjectsAsync(int userId);
        Task<Project> FindUserProjectAsync(int id, int userId);
    }
}
