﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenXKanCore.Data;

#nullable disable

namespace ZenXKanCore.Migrations
{
    [DbContext(typeof(ZenXKanContext))]
    [Migration("20240727153444_BatmanMigration")]
    partial class BatmanMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("ZenXKanCore.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_tags");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("ZenXKanCore.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("parent_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_tasks");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("ix_tasks_parent_id");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("ZenXKanCore.Models.TaskTag", b =>
                {
                    b.Property<Guid>("TaskId")
                        .HasColumnType("TEXT")
                        .HasColumnName("task_id");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT")
                        .HasColumnName("tag_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("TaskId", "TagId")
                        .HasName("pk_task_tags");

                    b.HasIndex("TagId")
                        .HasDatabaseName("ix_task_tags_tag_id");

                    b.ToTable("task_tags", (string)null);
                });

            modelBuilder.Entity("ZenXKanCore.Models.Task", b =>
                {
                    b.HasOne("ZenXKanCore.Models.Task", "Parent")
                        .WithMany("SubTasks")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_tasks_tasks_parent_id");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ZenXKanCore.Models.TaskTag", b =>
                {
                    b.HasOne("ZenXKanCore.Models.Tag", null)
                        .WithMany("TaskTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_tags_tags_tag_id");

                    b.HasOne("ZenXKanCore.Models.Task", null)
                        .WithMany("TaskTags")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_tags_tasks_task_id");
                });

            modelBuilder.Entity("ZenXKanCore.Models.Tag", b =>
                {
                    b.Navigation("TaskTags");
                });

            modelBuilder.Entity("ZenXKanCore.Models.Task", b =>
                {
                    b.Navigation("SubTasks");

                    b.Navigation("TaskTags");
                });
#pragma warning restore 612, 618
        }
    }
}
