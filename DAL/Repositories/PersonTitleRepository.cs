using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PersonTitleRepository : EFRepository<PersonTitle>, IPersonTitleRepository
    {
        public PersonTitleRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

