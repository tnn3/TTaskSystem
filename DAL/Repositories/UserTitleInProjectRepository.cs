using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserTitleInProjectRepository : EFRepository<UserTitleInProject>, IUserTitleInProjectRepository
    {
        public UserTitleInProjectRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

