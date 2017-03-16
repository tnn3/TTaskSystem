using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProjectRepository : EFRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

