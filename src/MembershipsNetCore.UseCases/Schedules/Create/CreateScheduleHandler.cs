using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.ScheduleAggregate;

namespace MembershipsNetCore.UseCases.Schedules.Create;

public class CreateAssigmentHandler : ICommandHandler<CreateScheduleCommand, Result<List<int>>>
{
  private readonly IRepository<Schedule> _repository;

  public CreateAssigmentHandler(IRepository<Schedule> repository)
  {
    _repository = repository;
  }

  public async Task<Result<List<int>>> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
  {
    var list = new List<int>();

    foreach (var schedule in request.ScheduleList)
    {
      var newSchedule = new Schedule(schedule.AssignmentId, schedule.DayOfWeek, schedule.HourOfDay, schedule.QuarterOfHour);

      var createditem = await _repository.AddAsync(newSchedule, cancellationToken);

      list.Add(createditem.Id);
    }

    return list;
  }
}

