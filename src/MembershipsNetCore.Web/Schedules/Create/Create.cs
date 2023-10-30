using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Schedules.Create;
using MembershipsNetCore.Web.Schedules.Create.DTOs;

namespace MembershipsNetCore.Web.Schedules.Create;

public class Create : Endpoint<CreateScheduleRequest, CreateScheduleResponse>
{
  private readonly IMediator _mediator;
  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateScheduleRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      var schedules = new List<ScheduleItem>();

      schedules.Add(new ScheduleItem(1, 0, 12, 0));
      schedules.Add(new ScheduleItem(1, 1, 12, 0));
      schedules.Add(new ScheduleItem(1, 5, 16, 0));
      schedules.Add(new ScheduleItem(1, 6, 16, 0));

      s.ExampleRequest = new CreateScheduleRequest {
        schedules = schedules
      };
    });
  }

  public override async Task HandleAsync(CreateScheduleRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateScheduleCommand(request.schedules!));

    if (result.IsSuccess)
    {
      Response = new CreateScheduleResponse(result.Value);
    }
  }
}
