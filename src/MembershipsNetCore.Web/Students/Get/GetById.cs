using FastEndpoints;
using MediatR;
using Ardalis.Result;
using MembershipsNetCore.Web.Endpoints.PersonEndpoints;
using MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;
using MembershipsNetCore.UseCases.Students.Get;
using MembershipsNetCore.UseCases.Persons.Get;

namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints;

public class GetById : Endpoint<GetStudentByIdRequest, StudentRecord>
{
  private readonly IMediator _mediator;

  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetStudentByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetStudentByIdRequest request,
    CancellationToken cancellationToken)
  {
    var studentCommand = new GetStudentQuery(request.StudentId);
    var resultStudent = await _mediator.Send(studentCommand);

    if (resultStudent.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var personCommand = new GetPersonQuery(resultStudent.Value.PersonId);
    var resultPerson = await _mediator.Send(personCommand);

    if (resultPerson.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }


    if (resultPerson.IsSuccess && resultStudent.IsSuccess)
    {
      var person = new PersonRecord(resultPerson.Value.Id, resultPerson.Value.FirstName, resultPerson.Value.LastName, resultPerson.Value.Age, resultPerson.Value.Email, resultPerson.Value.Status);
      Response = new StudentRecord(resultStudent.Value.Id, person);
    }
  }
}
