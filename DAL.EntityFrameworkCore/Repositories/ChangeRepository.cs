﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class ChangeRepository : EFRepository<Change>, IChangeRepository
    {
        public ChangeRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

