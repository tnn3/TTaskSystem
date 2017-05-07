using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

