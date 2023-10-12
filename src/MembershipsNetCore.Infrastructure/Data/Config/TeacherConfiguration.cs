using MembershipsNetCore.Core.TeacherAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MembershipsNetCore.Infrastructure.Data.Config;
public class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
{
  public void Configure(EntityTypeBuilder<Teacher> builder)
  {
    builder.Property(prop => prop.PersonId);
  }
}
