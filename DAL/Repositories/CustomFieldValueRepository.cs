using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public Task<List<CustomFieldValue>> AllAsyncWithIncludes()
        {
            return RepositoryDbSet.Include(c => c.CustomField).Include(c => c.ProjectTask).ToListAsync();
        }

        public Task<CustomFieldValue> FindAsyncWithIncludes(int id)
        {
            return RepositoryDbSet.Include(c => c.CustomField).Include(c => c.ProjectTask).SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
        }
    }
}

