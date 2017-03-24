using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomFieldValueRepository : EFRepository<CustomFieldValue>, ICustomFieldValueRepository
    {
        public CustomFieldValueRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

