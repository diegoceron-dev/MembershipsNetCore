using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MembershipsNetCore.Core.AssignmentAggregate;

namespace MembershipsNetCore.Infrastructure.Data.Config;
public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
  public void Configure(EntityTypeBuilder<Assignment> builder)
  {
    builder.Property(prop => prop.TeacherId);

    builder.Property(prop => prop.ClassId);

    builder.Property(prop => prop.DateInit);

    builder.Property(prop => prop.DateEnd);
  }
}
