﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL;
using Domain.Enums;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

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

                    b.Property<string>("ChangerId");

                    b.Property<string>("Comment");

                    b.Property<int>("ProjectTaskId");

                    b.Property<DateTime>("Time");

                    b.HasKey("ChangeSetId");

                    b.HasIndex("ChangerId");

                    b.HasIndex("ProjectTaskId");

                    b.ToTable("ChangeSets");
                });

            modelBuilder.Entity("Domain.CustomField", b =>
                {
                    b.Property<int>("CustomFieldId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FieldName");

                    b.Property<int>("FieldType");

                    b.Property<bool>("IsRequired");

                    b.Property<int>("MaxLength");

                    b.Property<int>("MinLength");

                    b.Property<string>("PossibleValues");

                    b.Property<int>("ProjectId");

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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("PriorityId");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedToId");

                    b.Property<string>("AuthorId");

                    b.Property<DateTime?>("Changed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("PriorityId");

                    b.Property<int>("ProjectId");

                    b.Property<int>("StatusId");

                    b.HasKey("ProjectTaskId");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Domain.StatusInProject", b =>
                {
                    b.Property<int>("StatusInProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("StatusId");

                    b.HasKey("StatusInProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("StatusInProjects");
                });

            modelBuilder.Entity("Domain.UserInProject", b =>
                {
                    b.Property<int>("UserInProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<string>("UserId");

                    b.Property<int>("UserTitleInProjectId");

                    b.HasKey("UserInProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserTitleInProjectId");

                    b.ToTable("UserInProjects");
                });

            modelBuilder.Entity("Domain.UserTitle", b =>
                {
                    b.Property<int>("UserTitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("UserTitleId");

                    b.ToTable("UserTitles");
                });

            modelBuilder.Entity("Domain.UserTitleInProject", b =>
                {
                    b.Property<int>("UserTitleInProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("TitleId");

                    b.HasKey("UserTitleInProjectId");

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
                        .HasForeignKey("ProjectTaskId");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.HasOne("Domain.ChangeSet", "ChangeSet")
                        .WithMany("Changes")
                        .HasForeignKey("ChangeSetId");
                });

            modelBuilder.Entity("Domain.ChangeSet", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser", "Changer")
                        .WithMany("ChangeSets")
                        .HasForeignKey("ChangerId");

                    b.HasOne("Domain.ProjectTask", "ProjectTask")
                        .WithMany("ChangeSets")
                        .HasForeignKey("ProjectTaskId");
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
                        .HasForeignKey("CustomFieldId");

                    b.HasOne("Domain.ProjectTask", "ProjectTask")
                        .WithMany("CustomFieldValue")
                        .HasForeignKey("ProjectTaskId");
                });

            modelBuilder.Entity("Domain.ProjectTask", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser", "AssignedTo")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("AssignedToId");

                    b.HasOne("Domain.Identity.ApplicationUser", "Author")
                        .WithMany("AuthorOfTasks")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.Priority", "Priority")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("PriorityId");

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Domain.StatusInProject", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("Domain.StatusInProject", b =>
                {
                    b.HasOne("Domain.Project", "Project")
                        .WithMany("StatusInProjects")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Domain.Status", "Status")
                        .WithMany("StatusInProjects")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("Domain.UserInProject", b =>
                {
                    b.HasOne("Domain.Project", "Project")
                        .WithMany("UsersInProject")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Domain.Identity.ApplicationUser", "User")
                        .WithMany("UserInProjects")
                        .HasForeignKey("UserId");

                    b.HasOne("Domain.UserTitleInProject", "TitleInProject")
                        .WithMany("UsersWithTitleInProject")
                        .HasForeignKey("UserTitleInProjectId");
                });

            modelBuilder.Entity("Domain.UserTitleInProject", b =>
                {
                    b.HasOne("Domain.Project", "Project")
                        .WithMany("TitlesInProject")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Domain.UserTitle", "Title")
                        .WithMany("TitlesInProjects")
                        .HasForeignKey("TitleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("Domain.Identity.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
