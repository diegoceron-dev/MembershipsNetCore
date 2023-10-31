using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.ScheduleAggregate;
using MembershipsNetCore.Core.ScheduleAggregate.Specifications;

namespace MembershipsNetCore.UseCases.Schedules.List;
public class ListScheduleHandler : IQueryHandler<ListScheduleQuery, Result<IEnumerable<ScheduleDTO>>>
{
  private readonly IReadRepository<Schedule> _repository;

  public ListScheduleHandler(IReadRepository<Schedule> repository)
  {
    _repository = repository;
  }

  public async Task<Result<IEnumerable<ScheduleDTO>>> Handle(ListScheduleQuery request, CancellationToken cancellationToken)
  {
    var spec = new SchedulesByFiltersSpec(null, null, request.teacherId, request.classId, request.scheduleId, request.assignmentId);

    var entity = (await (_repository).ListAsync(spec, cancellationToken))
      .Select(schedule => new ScheduleDTO(schedule.Id, schedule.DayOfWeek, schedule.HourOfDay,
      schedule.QuarterOfHour, schedule.Assignment!));

    if (entity == null) return Result.NotFound();

    return Result.Success(entity);

  }
}
