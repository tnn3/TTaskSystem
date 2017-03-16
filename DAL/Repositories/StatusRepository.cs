using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StatusRepository : EFRepository<Status>, IStatusRepository
    {
        public StatusRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

