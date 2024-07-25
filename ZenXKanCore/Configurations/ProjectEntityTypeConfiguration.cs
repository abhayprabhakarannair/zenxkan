using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenXKanCore.Models;

namespace ZenXKanCore.Configurations;

public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(t => t.Id).HasConversion(ConfigurationHelper.UlidValueConverter());

        builder.HasMany(t => t.Tasks).WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId).HasPrincipalKey(t => t.Id);
    }
}