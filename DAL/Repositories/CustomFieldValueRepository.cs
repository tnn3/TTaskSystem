using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomFieldValueRepository : EFRepository<CustomFieldValue>, ICustomFieldValueRepository
    {
        public CustomFieldValueRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}

