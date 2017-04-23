using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DomainUserConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId1",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInProjects_AspNetUsers_UserId1",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserInProjects_UserId1",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId1",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserInProjects");

            migrationBuilder.DropColumn(
                name: "AssignedToId1",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "ChangerId1",
                table: "ChangeSets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInProjects",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserInProjects_UserId",
                table: "UserInProjects",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets",
                column: "ChangerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
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
                name: "FK_UserInProjects_AspNetUsers_UserId",
                table: "UserInProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_AspNetUsers_ChangerId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AssignedToId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_AuthorId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInProjects_AspNetUsers_UserId",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserInProjects_UserId",
                table: "UserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AssignedToId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AuthorId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangerId",
                table: "ChangeSets");

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
                name: "IX_ProjectTasks_AssignedToId1",
                table: "ProjectTasks",
                column: "AssignedToId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AuthorId1",
                table: "ProjectTasks",
                column: "AuthorId1");

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
                name: "FK_UserInProjects_AspNetUsers_UserId1",
                table: "UserInProjects",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
