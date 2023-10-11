using MembershipsNetCore.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MembershipsNetCore.Infrastructure.Data.Config;
public class PersonConfiguration: IEntityTypeConfiguration<Person>
{

  public void Configure(EntityTypeBuilder<Person> builder)
  {
    builder.Property(prop => prop.FirstName).IsRequired()
        .HasMaxLength(DataSchemaConstants.DEFAULT_STRING_LENGTH);

    builder.Property(prop => prop.LastName).IsRequired()
        .HasMaxLength(DataSchemaConstants.DEFAULT_STRING_LENGTH);

    builder.Property(prop => prop.Age).IsRequired();

    builder.Property(prop => prop.Email).IsRequired()
        .HasMaxLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH);

    builder.Property(prop => prop.Status).HasConversion(x => x.Value, x => PersonStatus.FromValue(x)).IsRequired();
  }
}
