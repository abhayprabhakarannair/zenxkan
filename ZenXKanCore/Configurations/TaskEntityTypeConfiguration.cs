using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = ZenXKanCore.Models.Task;

namespace ZenXKanCore.Configurations;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.Property(t => t.Id).HasConversion(ConfigurationHelper.UlidValueConverter());
        builder.Property(t => t.ParentId).HasConversion(ConfigurationHelper.UlidValueConverter());
        builder.Property(t => t.ProjectId).HasConversion(ConfigurationHelper.UlidValueConverter());

        builder.HasMany(t => t.SubTasks).WithOne(t => t.Parent)
            .HasForeignKey(t => t.ParentId);

        builder.HasOne(t => t.Project).WithMany().HasForeignKey(t => t.ProjectId);
    }
}