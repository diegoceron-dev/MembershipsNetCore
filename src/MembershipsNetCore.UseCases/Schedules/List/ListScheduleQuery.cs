using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Schedules.List;

public record ListScheduleQuery(int? Skip, int? Take, int? teacherId, int? classId, int? scheduleId, int? assignmentId) : IQuery<Result<IEnumerable<ScheduleDTO>>>;
