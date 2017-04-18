using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Domain.Identity;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ClientRepository : EFRepository<ApplicationUser>, IClientRepository
    {
        public ClientRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

