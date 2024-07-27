using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenXKanCore.Models;
using Task = ZenXKanCore.Models.Task;

namespace ZenXKanCore.Configurations;

public class TaskEntityTypeConfiguration : BaseEntityTypeConfiguration<Task>
{
    public override void Configure(EntityTypeBuilder<Task> builder)
    {
        base.Configure(builder);

        builder.HasKey(t => t.Id);

        builder.HasMany(t => t.SubTasks).WithOne(t => t.Parent)
            .HasForeignKey(t => t.ParentId);

        builder.HasMany(t => t.Tags).WithMany(t => t.Tasks).UsingEntity<TaskTag>();
    }
}