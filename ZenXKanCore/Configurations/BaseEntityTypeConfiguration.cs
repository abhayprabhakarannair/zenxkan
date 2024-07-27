using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenXKanCore.Models;

namespace ZenXKanCore.Configurations;

public abstract class BaseEntityTypeConfiguration<TBaseType> : IEntityTypeConfiguration<TBaseType>
    where TBaseType : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBaseType> builder)
    {
        builder.Property(b => b.CreatedAt).IsRequired();
        builder.Property(b => b.UpdatedAt);
        builder.Property(b => b.DeletedAt);

        builder.HasQueryFilter(m => EF.Property<DateTime?>(m, "DeletedAt") == null);
    }
}