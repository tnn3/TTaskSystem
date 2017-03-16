using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TaskRepository : EFRepository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

