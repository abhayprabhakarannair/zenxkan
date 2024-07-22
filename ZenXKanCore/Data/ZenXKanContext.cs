using Microsoft.EntityFrameworkCore;
using ZenXKanCore.Configurations;
using Task = ZenXKanCore.Models.Task;

namespace ZenXKanCore.Data;

public class ZenXKanContext(DbContextOptions<ZenXKanContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());
    }
}