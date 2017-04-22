using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.temp
{
    public partial class TTaskSystemDbContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<ChangeSets> ChangeSets { get; set; }
        public virtual DbSet<Changes> Changes { get; set; }
        public virtual DbSet<CustomFieldValues> CustomFieldValues { get; set; }
        public virtual DbSet<CustomFields> CustomFields { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<ProjectTasks> ProjectTasks { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<UserTitleInProjects> UserTitleInProjects { get; set; }
        public virtual DbSet<UserTitles> UserTitles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TTaskSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.HasIndex(e => e.UserTitleId)
                    .HasName("IX_AspNetUsers_UserTitleId");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.UserTitle)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.UserTitleId);
            });

            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.HasKey(e => e.AttachmentId)
                    .HasName("PK_Attachments");

                entity.HasIndex(e => e.ProjectTaskId)
                    .HasName("IX_Attachments_ProjectTaskId");

                entity.Property(e => e.ProjectTaskId).HasDefaultValueSql("0");

                entity.HasOne(d => d.ProjectTask)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.ProjectTaskId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ChangeSets>(entity =>
            {
                entity.HasKey(e => e.ChangeSetId)
                    .HasName("PK_ChangeSets");

                entity.HasIndex(e => e.ChangerId)
                    .HasName("IX_ChangeSets_ChangerId");

                entity.HasIndex(e => e.ProjectTaskId)
                    .HasName("IX_ChangeSets_ProjectTaskId");

                entity.Property(e => e.ApplicationUserId).HasDefaultValueSql("0");

                entity.Property(e => e.ChangerId).HasMaxLength(450);

                entity.Property(e => e.ProjectTaskId).HasDefaultValueSql("0");

                entity.HasOne(d => d.Changer)
                    .WithMany(p => p.ChangeSets)
                    .HasForeignKey(d => d.ChangerId);

                entity.HasOne(d => d.ProjectTask)
                    .WithMany(p => p.ChangeSets)
                    .HasForeignKey(d => d.ProjectTaskId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Changes>(entity =>
            {
                entity.HasKey(e => e.ChangeId)
                    .HasName("PK_Changes");

                entity.HasIndex(e => e.ChangeSetId)
                    .HasName("IX_Changes_ChangeSetId");

                entity.Property(e => e.ChangeSetId).HasDefaultValueSql("0");

                entity.HasOne(d => d.ChangeSet)
                    .WithMany(p => p.Changes)
                    .HasForeignKey(d => d.ChangeSetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomFieldValues>(entity =>
            {
                entity.HasKey(e => e.CustomFieldValueId)
                    .HasName("PK_CustomFieldValues");

                entity.HasIndex(e => e.CustomFieldId)
                    .HasName("IX_CustomFieldValues_CustomFieldId");

                entity.HasIndex(e => e.ProjectTaskId)
                    .HasName("IX_CustomFieldValues_ProjectTaskId");

                entity.Property(e => e.ProjectTaskId).HasDefaultValueSql("0");

                entity.HasOne(d => d.CustomField)
                    .WithMany(p => p.CustomFieldValues)
                    .HasForeignKey(d => d.CustomFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProjectTask)
                    .WithMany(p => p.CustomFieldValues)
                    .HasForeignKey(d => d.ProjectTaskId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomFields>(entity =>
            {
                entity.HasKey(e => e.CustomFieldId)
                    .HasName("PK_CustomFields");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_CustomFields_ProjectId");

                entity.Property(e => e.CustomFieldValueId).HasDefaultValueSql("0");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.CustomFields)
                    .HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<Priorities>(entity =>
            {
                entity.HasKey(e => e.PriorityId)
                    .HasName("PK_Priorities");
            });

            modelBuilder.Entity<ProjectTasks>(entity =>
            {
                entity.HasKey(e => e.ProjectTaskId)
                    .HasName("PK_ProjectTasks");

                entity.HasIndex(e => e.AssignedToId1)
                    .HasName("IX_ProjectTasks_AssignedToId1");

                entity.HasIndex(e => e.AuthorId1)
                    .HasName("IX_ProjectTasks_AuthorId1");

                entity.HasIndex(e => e.PriorityId)
                    .HasName("IX_ProjectTasks_PriorityId");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_ProjectTasks_ProjectId");

                entity.HasIndex(e => e.StatusId)
                    .HasName("IX_ProjectTasks_StatusId");

                entity.Property(e => e.AssignedToId).HasDefaultValueSql("0");

                entity.Property(e => e.AssignedToId1).HasMaxLength(450);

                entity.Property(e => e.AuthorId).HasDefaultValueSql("0");

                entity.Property(e => e.AuthorId1).HasMaxLength(450);

                entity.Property(e => e.ProjectId).HasDefaultValueSql("0");

                entity.HasOne(d => d.AssignedToId1Navigation)
                    .WithMany(p => p.ProjectTasksAssignedToId1Navigation)
                    .HasForeignKey(d => d.AssignedToId1);

                entity.HasOne(d => d.AuthorId1Navigation)
                    .WithMany(p => p.ProjectTasksAuthorId1Navigation)
                    .HasForeignKey(d => d.AuthorId1);

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK_Projects");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Statuses");
            });

            modelBuilder.Entity<UserTitleInProjects>(entity =>
            {
                entity.HasKey(e => e.UserTitleInProjectId)
                    .HasName("PK_UserTitleInProjects");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_UserTitleInProjects_ApplicationUserId");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_UserTitleInProjects_ProjectId");

                entity.HasIndex(e => e.TitleId)
                    .HasName("IX_UserTitleInProjects_TitleId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(450);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserTitleInProjects)
                    .HasForeignKey(d => d.ApplicationUserId);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.UserTitleInProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.UserTitleInProjects)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserTitles>(entity =>
            {
                entity.HasKey(e => e.UserTitleId)
                    .HasName("PK_UserTitles");
            });
        }
    }
}