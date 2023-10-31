using MembershipsNetCore.Core.AssignmentAggregate;

namespace MembershipsNetCore.Web.Schedules;

public record ScheduleRecord(int Id, int DayOfWeek, int HourOfDay, int QuarterOfHour, int AssignmentId, int TeacherId, int ClassId);
