using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StatusRepository : EFRepository<Status>, IStatusRepository
    {
        public StatusRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

