using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;

namespace DAL.Repositories
{
    public class UserInProjectRepository : EFRepository<UserInProject>, IUserInProjectRepository
    {
        public UserInProjectRepository(IDataContext dataContext) : base(dataContext)
        {

        }
    }
}
