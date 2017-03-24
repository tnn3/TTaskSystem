using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PriorityRepository : EFRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

