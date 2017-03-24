using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    public partial class AddProjectTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    ChangeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    After = table.Column<string>(nullable: true),
                    Before = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.ChangeId);
                });

            migrationBuilder.CreateTable(
                name: "CustomFields",
                columns: table => new
                {
                    CustomFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldName = table.Column<string>(nullable: true),
                    FieldType = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    MaxLength = table.Column<int>(nullable: false),
                    MinLength = table.Column<int>(nullable: false),
                    PossibleValues = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFields", x => x.CustomFieldId);
                });

            migrationBuilder.CreateTable(
                name: "PersonTitles",
                columns: table => new
                {
                    PersonTitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTitles", x => x.PersonTitleId);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    PriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriorityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldValues",
                columns: table => new
                {
                    CustomFieldValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldId = table.Column<int>(nullable: false),
                    FieldValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldValues", x => x.CustomFieldValueId);
                    table.ForeignKey(
                        name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomFields",
                        principalColumn: "CustomFieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    PersonTitleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_PersonTitles_PersonTitleId",
                        column: x => x.PersonTitleId,
                        principalTable: "PersonTitles",
                        principalColumn: "PersonTitleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldInProjects",
                columns: table => new
                {
                    CustomFieldInProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldId = table.Column<int>(nullable: false),
                    FieldValueCustomFieldValueId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldInProjects", x => x.CustomFieldInProjectId);
                    table.ForeignKey(
                        name: "FK_CustomFieldInProjects_CustomFields_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomFields",
                        principalColumn: "CustomFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomFieldInProjects_CustomFieldValues_FieldValueCustomFieldValueId",
                        column: x => x.FieldValueCustomFieldValueId,
                        principalTable: "CustomFieldValues",
                        principalColumn: "CustomFieldValueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldInProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTitleInProjects",
                columns: table => new
                {
                    PersonTitleInProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTitleInProjects", x => x.PersonTitleInProjectId);
                    table.ForeignKey(
                        name: "FK_PersonTitleInProjects_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonTitleInProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTitleInProjects_PersonTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "PersonTitles",
                        principalColumn: "PersonTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ProjectTaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedToPersonId = table.Column<int>(nullable: true),
                    AuthorPersonId = table.Column<int>(nullable: true),
                    Changed = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PriorityId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    TaskName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ProjectTaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Persons_AssignedToPersonId",
                        column: x => x.AssignedToPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Persons_AuthorPersonId",
                        column: x => x.AuthorPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentLocation = table.Column<string>(nullable: true),
                    TaskProjectTaskId = table.Column<int>(nullable: true),
                    TimeUploaded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachments_Tasks_TaskProjectTaskId",
                        column: x => x.TaskProjectTaskId,
                        principalTable: "Tasks",
                        principalColumn: "ProjectTaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChangeSets",
                columns: table => new
                {
                    ChangeSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangerPersonId = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    TaskProjectTaskId = table.Column<int>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeSets", x => x.ChangeSetId);
                    table.ForeignKey(
                        name: "FK_ChangeSets_Persons_ChangerPersonId",
                        column: x => x.ChangerPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChangeSets_Tasks_TaskProjectTaskId",
                        column: x => x.TaskProjectTaskId,
                        principalTable: "Tasks",
                        principalColumn: "ProjectTaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TaskProjectTaskId",
                table: "Attachments",
                column: "TaskProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerPersonId",
                table: "ChangeSets",
                column: "ChangerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_TaskProjectTaskId",
                table: "ChangeSets",
                column: "TaskProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldInProjects_CustomFieldId",
                table: "CustomFieldInProjects",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldInProjects_FieldValueCustomFieldValueId",
                table: "CustomFieldInProjects",
                column: "FieldValueCustomFieldValueId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldInProjects_ProjectId",
                table: "CustomFieldInProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_CustomFieldId",
                table: "CustomFieldValues",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTitleId",
                table: "Persons",
                column: "PersonTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTitleInProjects_PersonId",
                table: "PersonTitleInProjects",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTitleInProjects_ProjectId",
                table: "PersonTitleInProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTitleInProjects_TitleId",
                table: "PersonTitleInProjects",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedToPersonId",
                table: "Tasks",
                column: "AssignedToPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorPersonId",
                table: "Tasks",
                column: "AuthorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Changes");

            migrationBuilder.DropTable(
                name: "ChangeSets");

            migrationBuilder.DropTable(
                name: "CustomFieldInProjects");

            migrationBuilder.DropTable(
                name: "PersonTitleInProjects");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "CustomFieldValues");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "CustomFields");

            migrationBuilder.DropTable(
                name: "PersonTitles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
