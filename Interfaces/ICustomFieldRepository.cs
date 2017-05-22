using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace Interfaces
{
    public interface ICustomFieldRepository : IRepository<CustomField>
    {
        Task<List<CustomField>> AllInProject(int projectId);
    }
}
