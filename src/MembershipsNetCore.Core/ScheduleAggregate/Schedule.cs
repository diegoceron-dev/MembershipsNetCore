using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.AssignmentAggregate;
using MembershipsNetCore.Core.ClassAggregate;

namespace MembershipsNetCore.Core.ScheduleAggregate;

public class Schedule: EntityBase, IAggregateRoot
{
  [ForeignKey("AssignmentId")]
  public Assignment? Assignment { get; set; }

  public int AssignmentId { get; private set; }

  public int DayOfWeek { get; private set; }

  public int HourOfDay { get; private set; }

  public int QuarterOfHour { get; private set; }

  public Schedule(int assignmentId, int dayOfWeek, int hourOfDay, int quarterOfHour)
  {
    AssignmentId = Guard.Against.NegativeOrZero(assignmentId, nameof(assignmentId));
    DayOfWeek = Guard.Against.Negative(dayOfWeek, nameof(dayOfWeek));
    HourOfDay = Guard.Against.Negative(hourOfDay, nameof(hourOfDay));
    QuarterOfHour = Guard.Against.Negative(quarterOfHour, nameof(quarterOfHour));
  }
}
