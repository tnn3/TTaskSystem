﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170316151042_InitialDbCreation")]
    partial class InitialDbCreation
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

                    b.Property<int?>("TaskId");

                    b.Property<DateTime>("TimeUploaded");

                    b.HasKey("AttachmentId");

                    b.HasIndex("TaskId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.Property<int>("ChangeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("After");

                    b.Property<string>("Before");

                    b.HasKey("ChangeId");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Domain.ChangeSet", b =>
                {
                    b.Property<int>("ChangeSetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChangerPersonId");

                    b.Property<string>("Comment");

                    b.Property<int?>("TaskId");

                    b.Property<DateTime>("Time");

                    b.HasKey("ChangeSetId");

                    b.HasIndex("ChangerPersonId");

                    b.HasIndex("TaskId");

                    b.ToTable("ChangeSets");
                });

            modelBuilder.Entity("Domain.CustomField", b =>
                {
                    b.Property<int>("CustomFieldId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FieldName");

                    b.Property<string>("FieldType");

                    b.Property<bool>("IsRequired");

                    b.Property<int>("MaxLength");

                    b.Property<int>("MinLength");

                    b.Property<string>("PossibleValues");

                    b.HasKey("CustomFieldId");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("Domain.CustomFieldInProject", b =>
                {
                    b.Property<int>("CustomFieldInProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldId");

                    b.Property<int?>("FieldValueCustomFieldValueId");

                    b.Property<int>("ProjectId");

                    b.HasKey("CustomFieldInProjectId");

                    b.HasIndex("CustomFieldId");

                    b.HasIndex("FieldValueCustomFieldValueId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CustomFieldInProjects");
                });

            modelBuilder.Entity("Domain.CustomFieldValue", b =>
                {
                    b.Property<int>("CustomFieldValueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFieldId");

                    b.Property<string>("FieldValue");

                    b.HasKey("CustomFieldValueId");

                    b.HasIndex("CustomFieldId");

                    b.ToTable("CustomFieldValues");
                });

            modelBuilder.Entity("Domain.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<int?>("PersonTitleId");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonTitleId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.PersonTitle", b =>
                {
                    b.Property<int>("PersonTitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TitleName");

                    b.HasKey("PersonTitleId");

                    b.ToTable("PersonTitles");
                });

            modelBuilder.Entity("Domain.PersonTitleInProject", b =>
                {
                    b.Property<int>("PersonTitleInProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("TitleId");

                    b.HasKey("PersonTitleInProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TitleId");

                    b.ToTable("PersonTitleInProjects");
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

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Domain.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssignedToPersonId");

                    b.Property<int?>("AuthorPersonId");

                    b.Property<DateTime>("Changed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<int?>("PriorityId");

                    b.Property<int?>("StatusId");

                    b.Property<string>("TaskName");

                    b.HasKey("TaskId");

                    b.HasIndex("AssignedToPersonId");

                    b.HasIndex("AuthorPersonId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Attachment", b =>
                {
                    b.HasOne("Domain.Task", "Task")
                        .WithMany("Attachments")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Domain.ChangeSet", b =>
                {
                    b.HasOne("Domain.Person", "Changer")
                        .WithMany()
                        .HasForeignKey("ChangerPersonId");

                    b.HasOne("Domain.Task", "Task")
                        .WithMany("ChangeSets")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Domain.CustomFieldInProject", b =>
                {
                    b.HasOne("Domain.CustomField", "CustomField")
                        .WithMany()
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.CustomFieldValue", "FieldValue")
                        .WithMany()
                        .HasForeignKey("FieldValueCustomFieldValueId");

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("CustomFields")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CustomFieldValue", b =>
                {
                    b.HasOne("Domain.CustomField", "CustomField")
                        .WithMany()
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Person", b =>
                {
                    b.HasOne("Domain.PersonTitle")
                        .WithMany("PersonsWithTitle")
                        .HasForeignKey("PersonTitleId");
                });

            modelBuilder.Entity("Domain.PersonTitleInProject", b =>
                {
                    b.HasOne("Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.PersonTitle", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Task", b =>
                {
                    b.HasOne("Domain.Person", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToPersonId");

                    b.HasOne("Domain.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorPersonId");

                    b.HasOne("Domain.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Domain.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
        }
    }
}
