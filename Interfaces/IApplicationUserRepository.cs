using System;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }
}