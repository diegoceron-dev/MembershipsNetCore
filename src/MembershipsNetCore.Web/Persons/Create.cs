using MembershipsNetCore.Core.PersonAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using MembershipsNetCore.Web.Endpoints.PersonEndpoints;
using MembershipsNetCore.UseCases.Persons.Create;
using MediatR;
namespace MembershipsNetCore.Web.Endpoints.PersonEndpoints;

public class Create: Endpoint<CreatePersonRequest, CreatePersonResponse>
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;

  public Create(IRepository<Person> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreatePersonRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreatePersonRequest { Age = 27, Email = "diegoceron.dev@outlook.com", FirstName = "Diego", LastName = "Ceron" }; 
    });
  }

  public override async Task HandleAsync(
    CreatePersonRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreatePersonCommand(request.FirstName!, request.LastName!, (int)request.Age!, request.Email!, PersonStatus.Active));

    if (result.IsSuccess)
    {
      Response = new CreatePersonResponse(result.Value, request.FirstName!, request.LastName!);
      return;
    }
    // TODO: Handle other cases as necessary
  }

}
