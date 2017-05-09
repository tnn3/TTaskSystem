using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFrameworkCore.Migrations
{
    public partial class AssignedToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "ProjectTasks",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "ProjectTasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
