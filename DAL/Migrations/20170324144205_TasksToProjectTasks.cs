using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TasksToProjectTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Tasks_TaskProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_Tasks_TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Persons_AssignedToPersonId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Persons_AuthorPersonId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Priorities_PriorityId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ProjectTasks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StatusId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_PriorityId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AuthorPersonId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_AuthorPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedToPersonId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_AssignedToPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_ProjectTasks_TaskProjectTaskId",
                table: "Attachments",
                column: "TaskProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ProjectTasks_TaskProjectTaskId",
                table: "ChangeSets",
                column: "TaskProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_ProjectTasks_TaskProjectTaskId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ProjectTasks_TaskProjectTaskId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Persons_AssignedToPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Persons_AuthorPersonId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Priorities_PriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks");

            migrationBuilder.RenameTable(
                name: "ProjectTasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_StatusId",
                table: "Tasks",
                newName: "IX_Tasks_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_PriorityId",
                table: "Tasks",
                newName: "IX_Tasks_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_AuthorPersonId",
                table: "Tasks",
                newName: "IX_Tasks_AuthorPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_AssignedToPersonId",
                table: "Tasks",
                newName: "IX_Tasks_AssignedToPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tasks_TaskProjectTaskId",
                table: "Attachments",
                column: "TaskProjectTaskId",
                principalTable: "Tasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_Tasks_TaskProjectTaskId",
                table: "ChangeSets",
                column: "TaskProjectTaskId",
                principalTable: "Tasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Persons_AssignedToPersonId",
                table: "Tasks",
                column: "AssignedToPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Persons_AuthorPersonId",
                table: "Tasks",
                column: "AuthorPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Priorities_PriorityId",
                table: "Tasks",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
