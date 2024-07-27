using Microsoft.EntityFrameworkCore;
using ZenXKanCore.Configurations;
using ZenXKanCore.Models;
using Task = ZenXKanCore.Models.Task;

namespace ZenXKanCore.Data;

public class ZenXKanContext(DbContextOptions<ZenXKanContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TaskTag> TaskTags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TaskTagEntityTypeConfiguration());
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries().Where(e =>
            e is { Entity: BaseEntity, State: EntityState.Added or EntityState.Modified or EntityState.Deleted });


        foreach (var entityEntry in entries)
        {
            var entityChanged = (BaseEntity)entityEntry.Entity;

            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityChanged.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entityChanged.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entityEntry.State = EntityState.Modified;
                    entityChanged.DeletedAt = DateTime.Now;
                    break;
            }
        }


        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e =>
            e is { Entity: BaseEntity, State: EntityState.Added or EntityState.Modified or EntityState.Deleted });


        foreach (var entityEntry in entries)
        {
            var entityChanged = (BaseEntity)entityEntry.Entity;

            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityChanged.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entityChanged.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entityEntry.State = EntityState.Modified;
                    entityChanged.DeletedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}