using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    public partial class SeparateUserClientAndCustomFieldChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_ProjectTasks_TaskProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ProjectTasks_TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Priorities_PriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "CustomFieldInProjects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AssignedToId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AuthorId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_TaskProjectTaskId",
                table: "Attachments");

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

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "ProjectTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "ProjectTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedToId1",
                table: "ProjectTasks",
                nullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "ChangerId",
                table: "ChangeSets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChangerId1",
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
                name: "IX_CustomFieldValues_ProjectTaskId",
                table: "CustomFieldValues",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_ProjectId",
                table: "CustomFields",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerId1",
                table: "ChangeSets",
                column: "ChangerId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_ProjectTasks_ProjectTaskId",
                table: "Attachments",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_ChangeSets_ChangeSetId",
                table: "Changes",
                column: "ChangeSetId",
                principalTable: "ChangeSets",
                principalColumn: "ChangeSetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId1",
                table: "ChangeSets",
                column: "ChangerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ProjectTasks_ProjectTaskId",
                table: "ChangeSets",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Projects_ProjectId",
                table: "CustomFields",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_ProjectTasks_ProjectTaskId",
                table: "CustomFieldValues",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ProjectTasks_Priorities_PriorityId",
                table: "ProjectTasks",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_ChangeSets_AspNetUsers_ChangerId1",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ProjectTasks_ProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Projects_ProjectId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValues_ProjectTasks_ProjectTaskId",
                table: "CustomFieldValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Priorities_PriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks");

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
                name: "IX_CustomFieldValues_ProjectTaskId",
                table: "CustomFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_ProjectId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId1",
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
                name: "AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectTasks");

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
                name: "ChangerId1",
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

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "ProjectTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToId",
                table: "ProjectTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ChangerId",
                table: "ChangeSets",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssignedToId",
                table: "ProjectTasks",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AuthorId",
                table: "ProjectTasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets",
                column: "ChangerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_ProjectTasks_TaskProjectTaskId",
                table: "Attachments",
                column: "TaskProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets",
                column: "ChangerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ProjectTasks_TaskProjectTaskId",
                table: "ChangeSets",
                column: "TaskProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId",
                table: "ProjectTasks",
                column: "AssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId",
                table: "ProjectTasks",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Priorities_PriorityId",
                table: "ProjectTasks",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
