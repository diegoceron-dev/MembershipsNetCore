using Ardalis.Result;
using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Persons.Get;
using MembershipsNetCore.UseCases.Teachers.Get;
using MembershipsNetCore.Web.Endpoints.PersonEndpoints;
using MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;
using MembershipsNetCore.Web.Teachers.Get.DTOs;

namespace MembershipsNetCore.Web.Teachers.Get;

public class GetById: Endpoint<GetTeacherByIdRequest, TeacherRecord>
{
  private readonly IMediator _mediator;
  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetTeacherByIdRequest.Route);
    AllowAnonymous();
  }

    public override async Task HandleAsync(GetTeacherByIdRequest request,
    CancellationToken cancellationToken)
  {
    var teacherCommand = new GetTeacherQuery(request.TeacherId);
    var resultTeacher = await _mediator.Send(teacherCommand);

    if (resultTeacher.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var personCommand = new GetPersonQuery(resultTeacher.Value.PersonId);
    var resultPerson = await _mediator.Send(personCommand);

    if (resultPerson.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }


    if (resultPerson.IsSuccess && resultTeacher.IsSuccess)
    {
      var person = new PersonRecord(resultPerson.Value.Id, resultPerson.Value.FirstName, resultPerson.Value.LastName, resultPerson.Value.Age, resultPerson.Value.Email, resultPerson.Value.Status);
      Response = new TeacherRecord(resultTeacher.Value.Id, person);
    }
  }

}
