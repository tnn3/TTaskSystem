using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    public partial class UserChangesAndRestricts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_ProjectTasks_TaskProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Persons_ChangerPersonId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ProjectTasks_TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                table: "CustomFieldValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Persons_AssignedToPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Persons_AuthorPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "CustomFieldInProjects");

            migrationBuilder.DropTable(
                name: "PersonTitleInProjects");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PersonTitles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AssignedToPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AuthorPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerPersonId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_TaskProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AssignedToPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AuthorPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "ChangerPersonId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "TaskProjectTaskId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "TimeUploaded",
                table: "Attachments",
                newName: "UploadedOn");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ProjectTasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "ProjectTasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssignedToId1",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTitleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "CustomFieldValues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomFieldValueId",
                table: "CustomFields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "CustomFields",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ChangeSets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChangerId",
                table: "ChangeSets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "ChangeSets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChangeSetId",
                table: "Changes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "Attachments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserTitles",
                columns: table => new
                {
                    UserTitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTitles", x => x.UserTitleId);
                });

            migrationBuilder.CreateTable(
                name: "UserTitleInProjects",
                columns: table => new
                {
                    UserTitleInProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTitleInProjects", x => x.UserTitleInProjectId);
                    table.ForeignKey(
                        name: "FK_UserTitleInProjects_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTitleInProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTitleInProjects_UserTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "UserTitles",
                        principalColumn: "UserTitleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssignedToId1",
                table: "ProjectTasks",
                column: "AssignedToId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AuthorId1",
                table: "ProjectTasks",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTitleId",
                table: "AspNetUsers",
                column: "UserTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_ProjectTaskId",
                table: "CustomFieldValues",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_ProjectId",
                table: "CustomFields",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets",
                column: "ChangerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ProjectTaskId",
                table: "ChangeSets",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_ChangeSetId",
                table: "Changes",
                column: "ChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProjectTaskId",
                table: "Attachments",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTitleInProjects_ApplicationUserId",
                table: "UserTitleInProjects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTitleInProjects_ProjectId",
                table: "UserTitleInProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTitleInProjects_TitleId",
                table: "UserTitleInProjects",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_ProjectTasks_ProjectTaskId",
                table: "Attachments",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_ChangeSets_ChangeSetId",
                table: "Changes",
                column: "ChangeSetId",
                principalTable: "ChangeSets",
                principalColumn: "ChangeSetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets",
                column: "ChangerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ProjectTasks_ProjectTaskId",
                table: "ChangeSets",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Projects_ProjectId",
                table: "CustomFields",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                table: "CustomFieldValues",
                column: "CustomFieldId",
                principalTable: "CustomFields",
                principalColumn: "CustomFieldId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_ProjectTasks_ProjectTaskId",
                table: "CustomFieldValues",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTitles_UserTitleId",
                table: "AspNetUsers",
                column: "UserTitleId",
                principalTable: "UserTitles",
                principalColumn: "UserTitleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId1",
                table: "ProjectTasks",
                column: "AssignedToId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId1",
                table: "ProjectTasks",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_ProjectTasks_ProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_ChangeSets_ChangeSetId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ProjectTasks_ProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Projects_ProjectId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                table: "CustomFieldValues");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValues_ProjectTasks_ProjectTaskId",
                table: "CustomFieldValues");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTitles_UserTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "UserTitleInProjects");

            migrationBuilder.DropTable(
                name: "UserTitles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomFieldValues_ProjectTaskId",
                table: "CustomFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_ProjectId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_Changes_ChangeSetId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_ProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "UserTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "CustomFieldValues");

            migrationBuilder.DropColumn(
                name: "CustomFieldValueId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "ChangeSetId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "UploadedOn",
                table: "Attachments",
                newName: "TimeUploaded");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ProjectTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "ProjectTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AssignedToPersonId",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorPersonId",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChangerPersonId",
                table: "ChangeSets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskProjectTaskId",
                table: "ChangeSets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskProjectTaskId",
                table: "Attachments",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssignedToPersonId",
                table: "ProjectTasks",
                column: "AssignedToPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AuthorPersonId",
                table: "ProjectTasks",
                column: "AuthorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerPersonId",
                table: "ChangeSets",
                column: "ChangerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_TaskProjectTaskId",
                table: "ChangeSets",
                column: "TaskProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TaskProjectTaskId",
                table: "Attachments",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_ProjectTasks_TaskProjectTaskId",
                table: "Attachments",
                column: "TaskProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Persons_ChangerPersonId",
                table: "ChangeSets",
                column: "ChangerPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ProjectTasks_TaskProjectTaskId",
                table: "ChangeSets",
                column: "TaskProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                table: "CustomFieldValues",
                column: "CustomFieldId",
                principalTable: "CustomFields",
                principalColumn: "CustomFieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Persons_AssignedToPersonId",
                table: "ProjectTasks",
                column: "AssignedToPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Persons_AuthorPersonId",
                table: "ProjectTasks",
                column: "AuthorPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
