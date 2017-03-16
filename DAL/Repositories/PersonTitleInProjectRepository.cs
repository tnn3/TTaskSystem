using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PersonTitleInProjectRepository : EFRepository<PersonTitleInProject>, IPersonTitleInProjectRepository
    {
        public PersonTitleInProjectRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

