using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChangeSetRepository : EFRepository<ChangeSet>, IChangeSetRepository
    {
        public ChangeSetRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

