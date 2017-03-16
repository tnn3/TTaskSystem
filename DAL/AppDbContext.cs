using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<ChangeSet> ChangeSets { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomFieldInProject> CustomFieldInProjects { get; set; }
        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonTitle> PersonTitles { get; set; }
        public DbSet<PersonTitleInProject> PersonTitleInProjects { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TTaskSystemDb;Trusted_Connection=true;");
        }
    }
}
