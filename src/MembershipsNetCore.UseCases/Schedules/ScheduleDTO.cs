using MembershipsNetCore.Core.AssignmentAggregate;

namespace MembershipsNetCore.UseCases.Schedules;

public record ScheduleDTO(int Id, int DayOfWeek, int HourOfDay, int QuarterOfHour, Assignment Assignment); // , int AssignmentId, int TeacherId, int ClassId);
