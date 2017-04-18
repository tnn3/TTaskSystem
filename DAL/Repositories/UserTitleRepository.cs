using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserTitleRepository : EFRepository<UserTitle>, IUserTitleRepository
    {
        public UserTitleRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

