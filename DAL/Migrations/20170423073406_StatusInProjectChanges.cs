using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class StatusInProjectChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusInProject_Projects_ProjectId",
                table: "StatusInProject");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusInProject_Statuses_StatusId",
                table: "StatusInProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusInProject",
                table: "StatusInProject");

            migrationBuilder.RenameTable(
                name: "StatusInProject",
                newName: "StatusInProjects");

            migrationBuilder.RenameIndex(
                name: "IX_StatusInProject_StatusId",
                table: "StatusInProjects",
                newName: "IX_StatusInProjects_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusInProject_ProjectId",
                table: "StatusInProjects",
                newName: "IX_StatusInProjects_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusInProjects",
                table: "StatusInProjects",
                column: "StatusInProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusInProjects_Projects_ProjectId",
                table: "StatusInProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusInProjects_Statuses_StatusId",
                table: "StatusInProjects",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusInProjects_Projects_ProjectId",
                table: "StatusInProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusInProjects_Statuses_StatusId",
                table: "StatusInProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusInProjects",
                table: "StatusInProjects");

            migrationBuilder.RenameTable(
                name: "StatusInProjects",
                newName: "StatusInProject");

            migrationBuilder.RenameIndex(
                name: "IX_StatusInProjects_StatusId",
                table: "StatusInProject",
                newName: "IX_StatusInProject_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusInProjects_ProjectId",
                table: "StatusInProject",
                newName: "IX_StatusInProject_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusInProject",
                table: "StatusInProject",
                column: "StatusInProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusInProject_Projects_ProjectId",
                table: "StatusInProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusInProject_Statuses_StatusId",
                table: "StatusInProject",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
