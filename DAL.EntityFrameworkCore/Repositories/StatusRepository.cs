using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class StatusRepository : EFRepository<Status>, IStatusRepository
    {
        public StatusRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

