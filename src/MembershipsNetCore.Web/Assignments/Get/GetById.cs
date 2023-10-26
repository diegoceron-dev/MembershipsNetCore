using Ardalis.Result;
using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Assignments.Get;
using MembershipsNetCore.UseCases.Classes.Get;
using MembershipsNetCore.Web.Assignments.Get.DTOs;
using MembershipsNetCore.Web.Classes;
using MembershipsNetCore.Web.Endpoints.ClassEndpoints.Get.DTOs;

namespace MembershipsNetCore.Web.Assignments.Get;

public class GetById : Endpoint<GetByIdAssignmentRequest, AssignmentRecord>
{
  private readonly IMediator _mediator;

  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetByIdAssignmentRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetByIdAssignmentRequest request, CancellationToken cancellationToken)
  {
    var command = new GetAssignmentQuery(request.AssignmentId);
    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new AssignmentRecord(result.Value.Id, result.Value.DateInit, result.Value.DateEnd, result.Value.TeacherId, result.Value.TeacherName, result.Value.ClassId, result.Value.ClassName);
    }

  }

}
