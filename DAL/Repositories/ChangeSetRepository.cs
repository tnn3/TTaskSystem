using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChangeSetRepository : EFRepository<ChangeSet>, IChangeSetRepository
    {
        public ChangeSetRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

