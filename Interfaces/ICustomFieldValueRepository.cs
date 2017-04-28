using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces
{
    public interface ICustomFieldValueRepository : IRepository<CustomFieldValue>
    {
        Task<List<CustomFieldValue>> AllAsyncWithIncludes();
        Task<CustomFieldValue> FindAsyncWithIncludes(int id);
    }
}
