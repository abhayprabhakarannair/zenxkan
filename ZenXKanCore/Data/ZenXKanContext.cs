using Microsoft.EntityFrameworkCore;
using ZenXKanCore.Configurations;
using ZenXKanCore.Models;
using Task = ZenXKanCore.Models.Task;

namespace ZenXKanCore.Data;

public class ZenXKanContext(DbContextOptions<ZenXKanContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
    }
}