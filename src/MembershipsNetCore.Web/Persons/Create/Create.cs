using MembershipsNetCore.Core.PersonAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using MembershipsNetCore.UseCases.Persons.Create;
using MediatR;
using MembershipsNetCore.Web.Persons.Create.DTOs;

namespace MembershipsNetCore.Web.Persons.Create;

public class Create : Endpoint<Request, Response>
{
  private readonly IMediator _mediator;

  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(Request.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new Request { Age = 27, Email = "diegoceron.dev@outlook.com", FirstName = "Diego", LastName = "Ceron" };
    });
  }

  public override async Task HandleAsync(
    Request request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreatePersonCommand(request.FirstName!, request.LastName!, (int)request.Age!, request.Email!, PersonStatus.Active));

    if (result.IsSuccess)
    {
      Response = new Response(result.Value, request.FirstName!, request.LastName!);
      return;
    }
    // TODO: Handle other cases as necessary
  }

}
