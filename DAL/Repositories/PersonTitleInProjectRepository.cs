using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PersonTitleInProjectRepository : EFRepository<PersonTitleInProject>, IPersonTitleInProjectRepository
    {
        public PersonTitleInProjectRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

