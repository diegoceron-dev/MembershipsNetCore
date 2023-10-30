using MembershipsNetCore.UseCases.Assignments.Create;
using MembershipsNetCore.Web.Assignments.Create.DTOs;
using FastEndpoints;
using MediatR;

namespace MembershipsNetCore.Web.Assignments.Create;

public class Create : Endpoint<CreateAssignmentRequest, CreateAssignmentResponse>
{
  private readonly IMediator _mediator;
  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateAssignmentRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateAssignmentRequest { DateInit = "151984000000", DateEnd = "151984000000", ClassId = 1, TeacherId = 2 };
    });
  }

  public override async Task HandleAsync(CreateAssignmentRequest request, CancellationToken cancellationToken)
  {
    var dateInit = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(request.DateInit));
    var dateEnd = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(request.DateEnd));

    var result = await _mediator.Send(new CreateAssignmentCommand(dateInit, dateEnd, request.TeacherId, request.ClassId));

    if (result.IsSuccess)
    {
      Response = new CreateAssignmentResponse(result.Value, dateInit, dateEnd, request.TeacherId, request.ClassId);
    }
  }
}
