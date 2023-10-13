using MembershipsNetCore.Core.TeacherAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using MembershipsNetCore.UseCases.Teachers.Create;
using MediatR;
using MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;

namespace MembershipsNetCore.Web.Endpoints.TeacherEndpoints;

public class Create : Endpoint<Request, Response>
{
  private readonly IRepository<Teacher> _repository;
  private readonly IMediator _mediator;

  public Create(IRepository<Teacher> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(Request.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new Request { IdPerson = 1 };
    });
  }

  public override async Task HandleAsync(
    Request request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateTeacherCommand((int)request.IdPerson!));

    if (result.IsSuccess)
    {
      Response = new Response(result.Value, (int)request.IdPerson!);
      return;
    }
    // TODO: Handle other cases as necessary
  }

}
