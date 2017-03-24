using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChangeRepository : EFRepository<Change>, IChangeRepository
    {
        public ChangeRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

