using MediatR;
using FastEndpoints;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.StudentAggregate;
using MembershipsNetCore.UseCases.Students.Create;
using MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;
using MembershipsNetCore.Core.PersonAggregate;
using MembershipsNetCore.UseCases.Persons.Create;
using MembershipsNetCore.UseCases.Teachers.Create;

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
        var resultStudent = await _mediator.Send(new CreateStudentCommand((int)resultPerson.Value!));

        if (resultStudent.IsSuccess)
        {
          Response = new Response(resultStudent.Value, (int)resultPerson.Value!);
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
