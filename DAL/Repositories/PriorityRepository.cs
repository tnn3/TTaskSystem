using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PriorityRepository : EFRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

