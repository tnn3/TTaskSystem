using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    public partial class AddUserInProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTitles_UserTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTitleInProjects_AspNetUsers_ApplicationUserId",
                table: "UserTitleInProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserTitleInProjects_ApplicationUserId",
                table: "UserTitleInProjects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserTitleInProjects");

            migrationBuilder.DropColumn(
                name: "UserTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomFieldValueId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "After",
                table: "Changes");

            migrationBuilder.AlterColumn<int>(
                name: "FieldType",
                table: "CustomFields",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserInProjects",
                columns: table => new
                {
                    UserInProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserTitleInProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInProjects", x => x.UserInProjectId);
                    table.ForeignKey(
                        name: "FK_UserInProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInProjects_UserTitleInProjects_UserTitleInProjectId",
                        column: x => x.UserTitleInProjectId,
                        principalTable: "UserTitleInProjects",
                        principalColumn: "UserTitleInProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInProjects_ProjectId",
                table: "UserInProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInProjects_UserId",
                table: "UserInProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInProjects_UserTitleInProjectId",
                table: "UserInProjects",
                column: "UserTitleInProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInProjects");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserTitleInProjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTitleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FieldType",
                table: "CustomFields",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CustomFieldValueId",
                table: "CustomFields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "After",
                table: "Changes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTitleInProjects_ApplicationUserId",
                table: "UserTitleInProjects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTitleId",
                table: "AspNetUsers",
                column: "UserTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTitles_UserTitleId",
                table: "AspNetUsers",
                column: "UserTitleId",
                principalTable: "UserTitles",
                principalColumn: "UserTitleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTitleInProjects_AspNetUsers_ApplicationUserId",
                table: "UserTitleInProjects",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
