using System.Reflection.Emit;
using System.Reflection.Metadata;
using MembershipsNetCore.Core.PersonAggregate;
using MembershipsNetCore.Core.StudentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MembershipsNetCore.Infrastructure.Data.Config;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.Property(prop => prop.PersonId);
  }
}
