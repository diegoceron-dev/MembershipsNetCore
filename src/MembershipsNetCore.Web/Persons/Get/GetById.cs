using FastEndpoints;
using MediatR;
using Ardalis.Result;
using MembershipsNetCore.Web.Endpoints.PersonEndpoints;
using MembershipsNetCore.UseCases.Persons.Get;

namespace MembershipsNetCore.Web.Persons.Get;

public class GetById: Endpoint<GetPersonByIdRequest, PersonRecord>
{
  private readonly IMediator _mediator;

  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetPersonByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetPersonByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetPersonQuery(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new PersonRecord(result.Value.Id, result.Value.FirstName, result.Value.LastName, result.Value.Age, result.Value.Email, result.Value.Status);
    }
  }
}
