using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomFieldInProjectRepository : EFRepository<CustomFieldInProject>, ICustomFieldInProjectRepository
    {
        public CustomFieldInProjectRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

