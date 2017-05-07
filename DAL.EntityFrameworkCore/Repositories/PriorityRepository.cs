using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class PriorityRepository : EFRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

