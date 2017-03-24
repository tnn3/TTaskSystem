using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProjectTaskRepository : EFRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

