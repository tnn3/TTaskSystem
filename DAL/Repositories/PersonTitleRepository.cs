using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PersonTitleRepository : EFRepository<PersonTitle>, IPersonTitleRepository
    {
        public PersonTitleRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

