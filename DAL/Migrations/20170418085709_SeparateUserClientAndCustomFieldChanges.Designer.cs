using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170418085709_SeparateUserClientAndCustomFieldChanges")]
    partial class SeparateUserClientAndCustomFieldChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentLocation");

                    b.Property<int>("ProjectTaskId");

                    b.Property<DateTime>("UploadedOn");

                    b.HasKey("AttachmentId");

                    b.HasIndex("ProjectTaskId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.Property<int>("ChangeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("After");

                    b.Property<string>("Before");

                    b.Property<int>("ChangeSetId");

                    b.HasKey("ChangeId");

                    b.HasIndex("ChangeSetId");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Domain.ChangeSet", b =>
                {
                    b.Property<int>("ChangeSetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChangerId");

                    b.Property<string>("ChangerId1");

                    b.Property<string>("Comment");

                    b.Property<int>("ProjectTaskId");

                    b.Property<DateTime>("Time");

                    b.HasKey("ChangeSetId");

                    b.HasIndex("ChangerId1");

                    b.HasIndex("ProjectTaskId");

                    b.ToTable("ChangeSets");
                });

            modelBuilder.Entity("Domain.CustomField", b =>
                {
                    b.Property<int>("CustomFieldId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldValueId");

                    b.Property<string>("FieldName");

                    b.Property<string>("FieldType");

                    b.Property<bool>("IsRequired");

                    b.Property<int>("MaxLength");

                    b.Property<int>("MinLength");

                    b.Property<string>("PossibleValues");

                    b.Property<int?>("ProjectId");

                    b.HasKey("CustomFieldId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("Domain.CustomFieldValue", b =>
                {
                    b.Property<int>("CustomFieldValueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldId");

                    b.Property<string>("FieldValue");

                    b.Property<int>("ProjectTaskId");

                    b.HasKey("CustomFieldValueId");

                    b.HasIndex("CustomFieldId");

                    b.HasIndex("ProjectTaskId");

                    b.ToTable("CustomFieldValues");
                });

            modelBuilder.Entity("Domain.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int?>("UserTitleId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("UserTitleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PriorityName");

                    b.HasKey("PriorityId");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ProjectDescription");

                    b.Property<string>("ProjectName");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssignedToId");

                    b.Property<string>("AssignedToId1");

                    b.Property<int>("AuthorId");

                    b.Property<string>("AuthorId1");

                    b.Property<DateTime>("Changed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("PriorityId");

                    b.Property<int>("ProjectId");

                    b.Property<int>("StatusId");

                    b.Property<string>("TaskName");

                    b.HasKey("ProjectTaskId");

                    b.HasIndex("AssignedToId1");

                    b.HasIndex("AuthorId1");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Domain.UserTitle", b =>
                {
                    b.Property<int>("UserTitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TitleName");

                    b.HasKey("UserTitleId");

                    b.ToTable("UserTitles");
                });

            modelBuilder.Entity("Domain.UserTitleInProject", b =>
                {
                    b.Property<int>("UserTitleInProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("ProjectId");

                    b.Property<int>("TitleId");

                    b.HasKey("UserTitleInProjectId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TitleId");

                    b.ToTable("UserTitleInProjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Attachment", b =>
                {
                    b.HasOne("Domain.ProjectTask", "ProjectTask")
                        .WithMany("Attachments")
                        .HasForeignKey("ProjectTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.HasOne("Domain.ChangeSet", "ChangeSet")
                        .WithMany("Changes")
                        .HasForeignKey("ChangeSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.ChangeSet", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser", "Changer")
                        .WithMany()
                        .HasForeignKey("ChangerId1");

                    b.HasOne("Domain.ProjectTask", "ProjectTask")
                        .WithMany("ChangeSets")
                        .HasForeignKey("ProjectTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CustomField", b =>
                {
                    b.HasOne("Domain.Project", "Project")
                        .WithMany("CustomFields")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Domain.CustomFieldValue", b =>
                {
                    b.HasOne("Domain.CustomField", "CustomField")
                        .WithMany("CustomFieldValues")
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.ProjectTask", "ProjectTask")
                        .WithMany("CustomFieldValue")
                        .HasForeignKey("ProjectTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Identity.ApplicationUser", b =>
                {
                    b.HasOne("Domain.UserTitle")
                        .WithMany("UsersWithTitle")
                        .HasForeignKey("UserTitleId");
                });

            modelBuilder.Entity("Domain.ProjectTask", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser", "AssignedTo")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("AssignedToId1");

                    b.HasOne("Domain.Identity.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId1");

                    b.HasOne("Domain.Priority", "Priority")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Status", "Status")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.UserTitleInProject", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Titles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.UserTitle", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
