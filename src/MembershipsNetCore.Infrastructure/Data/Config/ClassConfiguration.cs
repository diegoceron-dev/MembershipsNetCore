using MembershipsNetCore.Core.ClassAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MembershipsNetCore.Infrastructure.Data.Config;
public class ClassConfiguration : IEntityTypeConfiguration<Class>
{

  public void Configure(EntityTypeBuilder<Class> builder)
  {
    builder.Property(prop => prop.Name).IsRequired()
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    builder.Property(prop => prop.Status).HasConversion(x => x.Value, x => ClassStatus.FromValue(x)).IsRequired();
  }
}
