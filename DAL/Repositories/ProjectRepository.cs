using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProjectRepository : EFRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

