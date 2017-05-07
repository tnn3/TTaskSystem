using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Domain;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class ChangeSetRepository : EFRepository<ChangeSet>, IChangeSetRepository
    {
        public ChangeSetRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

