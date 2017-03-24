using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomFieldRepository : EFRepository<CustomField>, ICustomFieldRepository
    {
        public CustomFieldRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}

