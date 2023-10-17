using Ardalis.Result;
using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Classes.Get;
using MembershipsNetCore.Web.Endpoints.ClassEndpoints.Get.DTOs;

namespace MembershipsNetCore.Web.Classes.Get;

public class GetById : Endpoint<GetClassByIdRequest, ClassRecord>
{
  private readonly IMediator _mediator;

  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetClassByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetClassByIdRequest request, CancellationToken cancellationToken)
  {
    var command = new GetClassQuery(request.ClassId);
    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ClassRecord(result.Value.Id, result.Value.Name, result.Value.Status!);
    }

  }
}
