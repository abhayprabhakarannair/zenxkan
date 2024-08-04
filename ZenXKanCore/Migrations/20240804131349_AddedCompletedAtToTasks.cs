using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenXKanCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompletedAtToTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "completed_at",
                table: "tasks",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completed_at",
                table: "tasks");
        }
    }
}
