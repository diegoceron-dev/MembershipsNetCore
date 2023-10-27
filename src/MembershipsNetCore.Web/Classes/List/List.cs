using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Classes.List;
using MembershipsNetCore.Web.Classes;
using MembershipsNetCore.Web.Endpoints.ClassEndpoints.Get.DTOs;

namespace MembershipsNetCore.Web.Endpoints.ClassEndpoints;

public class List : EndpointWithoutRequest<ListClassResponse>
{
  private readonly IMediator _mediator;

  public List(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/Classes");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListClassesQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new ListClassResponse
      {
        Classes = result.Value.
        Select(c => new 
          ClassRecord(c.Id, c.Name, c.Status!)
        ).ToList()
      };
    }
  }
}
