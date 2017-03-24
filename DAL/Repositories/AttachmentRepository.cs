using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AttachmentRepository : EFRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}
