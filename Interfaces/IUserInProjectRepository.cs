﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface IUserInProjectRepository : IRepository<UserInProject>
    {
        Task<List<UserInProject>> AllAsyncWithIncludes();
        Task<UserInProject> FindAsyncWithIncludes(int id);
        Task<List<UserInProject>> AllInProject(int projectId);
    }
}
