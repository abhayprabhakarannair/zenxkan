using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenXKanCore.Models;

namespace ZenXKanCore.Configurations;

public class TaskTagEntityTypeConfiguration : BaseEntityTypeConfiguration<TaskTag>
{
    public override void Configure(EntityTypeBuilder<TaskTag> builder)
    {
        base.Configure(builder);

        builder.HasKey(t => new { t.TaskId, t.TagId });
    }
}