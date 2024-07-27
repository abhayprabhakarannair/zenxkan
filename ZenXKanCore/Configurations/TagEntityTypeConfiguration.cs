using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenXKanCore.Models;

namespace ZenXKanCore.Configurations;

public class TagEntityTypeConfiguration : BaseEntityTypeConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        base.Configure(builder);

        builder.HasKey(t => t.Id);
    }
}