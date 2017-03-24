using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

