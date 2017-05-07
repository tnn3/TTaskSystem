using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;

namespace DAL.EntityFrameworkCore.Repositories
{
    public class AttachmentRepository : EFRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}
