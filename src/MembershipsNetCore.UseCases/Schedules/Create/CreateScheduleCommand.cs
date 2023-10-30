using Ardalis.Result;

namespace MembershipsNetCore.UseCases.Schedules.Create;

public record ScheduleItem (int AssignmentId, int DayOfWeek, int HourOfDay, int QuarterOfHour);
public record CreateScheduleCommand(List<ScheduleItem> ScheduleList) : Ardalis.SharedKernel.ICommand<Result<List<int>>>;
