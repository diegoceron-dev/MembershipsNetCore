using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MembershipsNetCore.Core.ScheduleAggregate;

namespace MembershipsNetCore.Infrastructure.Data.Config;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
  public void Configure(EntityTypeBuilder<Schedule> builder)
  {
    builder.Property(prop => prop.AssignmentId);

    builder.Property(prop => prop.DayOfWeek);

    builder.Property(prop => prop.HourOfDay);

    builder.Property(prop => prop.QuarterOfHour);
  }
}
