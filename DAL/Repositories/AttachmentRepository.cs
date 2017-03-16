using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AttachmentRepository : EFRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(DbContext dbContext) : base(dbContext: dbContext)
        {

        }
    }
}
