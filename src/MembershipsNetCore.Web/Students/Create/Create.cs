using MediatR;
using FastEndpoints;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.StudentAggregate;
using MembershipsNetCore.UseCases.Students.Create;
using MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;

namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints;
public class Create : Endpoint<Request, Response>
{

  private readonly IRepository<Student> _repository;
  private readonly IMediator _mediator;

  public Create(IRepository<Student> repository, IMediator mediator)
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
    var result = await _mediator.Send(new CreateStudentCommand((int)request.IdPerson!));

    if (result.IsSuccess)
    {
      Response = new Response(result.Value, (int)request.IdPerson!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
