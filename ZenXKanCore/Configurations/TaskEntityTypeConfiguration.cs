using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task = ZenXKanCore.Models.Task;

namespace ZenXKanCore.Configurations;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        var ulidToStringConverter = new ValueConverter<Ulid, string>(
            model => model.ToString(), value => Ulid.Parse(value));

        builder.Property(t => t.Id).HasConversion(ulidToStringConverter);
        builder.Property(t => t.ParentId).HasConversion(ulidToStringConverter);

        builder.HasMany(t => t.SubTasks).WithOne(t => t.Parent)
            .HasForeignKey(t => t.ParentId);
    }
}