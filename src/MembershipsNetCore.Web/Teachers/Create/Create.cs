using MembershipsNetCore.Core.TeacherAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using MembershipsNetCore.UseCases.Teachers.Create;
using MediatR;
using MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;
using MembershipsNetCore.Core.PersonAggregate;
using MembershipsNetCore.UseCases.Persons.Create;

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
      s.ExampleRequest = new Request { Age = 28, Email = "diegoceron.dev@outlook.com", FirstName = "DIEGO", LastName = "CERON" };
    });
  }

  public override async Task HandleAsync(
    Request request,
    CancellationToken cancellationToken)
  {
    try
    {
      var resultPerson = await _mediator.Send(new CreatePersonCommand(request.FirstName!, request.LastName!, (int)request.Age!, request.Email!, PersonStatus.Active));

      if (resultPerson.IsSuccess)
      {
        var resultTeacher = await _mediator.Send(new CreateTeacherCommand((int)resultPerson.Value!));

        if (resultTeacher.IsSuccess)
        {
          Response = new Response(resultTeacher.Value, (int)resultPerson.Value!);
          return;
        }
      }

      throw new Exception();
    }
    catch (Exception)
    {
      return;
    }
  }

}
