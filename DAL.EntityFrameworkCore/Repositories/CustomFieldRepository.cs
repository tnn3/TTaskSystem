using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class CustomFieldRepository : EFRepository<CustomField>, ICustomFieldRepository
    {
        public CustomFieldRepository(IDataContext dbContext) : base(dbContext)
        {

        }

        public Task<List<CustomField>> AllInProject(int projectId)
        {
            return RepositoryDbSet
                .Include(p => p.Project)
                .Where(p => p.Project.ProjectId == projectId)
                .ToListAsync();
        }
    }
}

