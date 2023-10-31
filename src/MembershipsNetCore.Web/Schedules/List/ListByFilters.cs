using Ardalis.Result;
using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Schedules.List;
using MembershipsNetCore.Web.Schedules.List.DTOs;
namespace MembershipsNetCore.Web.Schedules.List;

public class ListByFilters : Endpoint<ListScheduleRequest, ListScheduleResponse>
{
  private readonly IMediator _mediator;
  public ListByFilters(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(ListScheduleRequest.Route);
    AllowAnonymous();
  }
  public override async Task HandleAsync(ListScheduleRequest request, CancellationToken cancellationToken)
  {
    var command = new ListScheduleQuery(request.Skip, request.Take, request.TeacherId, request.ClassId, request.ScheduleId, request.AssignmentId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ListScheduleResponse
      {
        Schedules = result.Value.Select(
             c => new ScheduleRecord(c.Id, c.DayOfWeek, c.HourOfDay, c.QuarterOfHour, c.Assignment.Id, c.Assignment.TeacherId, c.Assignment.ClassId)
            ).ToList()
      };
    }
  }
}

