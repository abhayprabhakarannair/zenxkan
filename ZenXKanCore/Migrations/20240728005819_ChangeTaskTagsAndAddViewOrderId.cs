using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenXKanCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTaskTagsAndAddViewOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_task_tags",
                table: "task_tags");

            migrationBuilder.DropIndex(
                name: "ix_task_tags_tag_id",
                table: "task_tags");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "task_tags");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "task_tags");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "task_tags");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "view_order_id",
                table: "tasks",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_task_tags",
                table: "task_tags",
                columns: new[] { "tag_id", "task_id" });

            migrationBuilder.CreateIndex(
                name: "ix_task_tags_task_id",
                table: "task_tags",
                column: "task_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_task_tags",
                table: "task_tags");

            migrationBuilder.DropIndex(
                name: "ix_task_tags_task_id",
                table: "task_tags");

            migrationBuilder.DropColumn(
                name: "description",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "view_order_id",
                table: "tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "task_tags",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "task_tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "task_tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_task_tags",
                table: "task_tags",
                columns: new[] { "task_id", "tag_id" });

            migrationBuilder.CreateIndex(
                name: "ix_task_tags_tag_id",
                table: "task_tags",
                column: "tag_id");
        }
    }
}
