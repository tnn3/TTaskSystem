using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class ApplicationUserRepository : EFRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDataContext dataContext) : base(dataContext: dataContext)
        {
            
        }
    }
}
