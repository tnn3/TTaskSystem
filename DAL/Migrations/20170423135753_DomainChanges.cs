using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DomainChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInProjects_AspNetUsers_UserId",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserInProjects_UserId",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserInProjects");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ChangeSets");

            migrationBuilder.RenameColumn(
                name: "TitleName",
                table: "UserTitles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "StatusName",
                table: "Statuses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PriorityName",
                table: "Priorities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AttachmentLocation",
                table: "Attachments",
                newName: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserInProjects",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserInProjects",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserInProjects_UserId1",
                table: "UserInProjects",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerId1",
                table: "ChangeSets",
                column: "ChangerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId1",
                table: "ChangeSets",
                column: "ChangerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_StatusInProjects_StatusId",
                table: "ProjectTasks",
                column: "StatusId",
                principalTable: "StatusInProjects",
                principalColumn: "StatusInProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInProjects_AspNetUsers_UserId1",
                table: "UserInProjects",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId1",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_StatusInProjects_StatusId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInProjects_AspNetUsers_UserId1",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserInProjects_UserId1",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId1",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserInProjects");

            migrationBuilder.DropColumn(
                name: "ChangerId1",
                table: "ChangeSets");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserTitles",
                newName: "TitleName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Statuses",
                newName: "StatusName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "ProjectDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Priorities",
                newName: "PriorityName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Attachments",
                newName: "AttachmentLocation");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInProjects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserInProjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ChangerId",
                table: "ChangeSets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ChangeSets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserInProjects_UserId",
                table: "UserInProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets",
                column: "ChangerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets",
                column: "ChangerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Statuses_StatusId",
                table: "ProjectTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInProjects_AspNetUsers_UserId",
                table: "UserInProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
