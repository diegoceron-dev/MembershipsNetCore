using MembershipsNetCore.Core.ClassAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using MembershipsNetCore.UseCases.Classes.Create;
using MediatR;
using MembershipsNetCore.Web.Classes.Create.DTOs;
namespace MembershipsNetCore.Web.Classes.Create;

public class Create : Endpoint<CreateClassRequest, CreateClassResponse>
{
  private readonly IMediator _mediator;

  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateClassRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateClassRequest { Name = "Box"};
    });
  }

  public override async Task HandleAsync(CreateClassRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateClassCommand(request.Name!, ClassStatus.Active));

    if (result.IsSuccess)
    {
      Response = new CreateClassResponse(result.Value, request.Name!);
    }
  }
}
