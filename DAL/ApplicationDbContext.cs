using System.Linq;
using Domain.Identity;
using Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        //use fully qualified names for scaffolding
        public DbSet<Domain.Attachment> Attachments { get; set; }
        public DbSet<Domain.Change> Changes { get; set; }
        public DbSet<Domain.ChangeSet> ChangeSets { get; set; }
        public DbSet<Domain.CustomField> CustomFields { get; set; }
        public DbSet<Domain.CustomFieldValue> CustomFieldValues { get; set; }
        public DbSet<Domain.Identity.ApplicationUser> People { get; set; }
        public DbSet<Domain.UserTitle> UserTitles { get; set; }
        public DbSet<Domain.UserTitleInProject> UserTitleInProjects { get; set; }
        public DbSet<Domain.Priority> Priorities { get; set; }
        public DbSet<Domain.Project> Projects { get; set; }
        public DbSet<Domain.Status> Statuses { get; set; }
        public DbSet<Domain.ProjectTask> ProjectTasks { get; set; }
        public DbSet<Domain.UserInProject> UserInProjects { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
