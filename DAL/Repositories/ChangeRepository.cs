using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChangeRepository : EFRepository<Change>, IChangeRepository
    {
        public ChangeRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

