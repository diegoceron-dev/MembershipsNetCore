using Ardalis.Result;
using FastEndpoints;
using MediatR;
using MembershipsNetCore.UseCases.Assignments.List;
using MembershipsNetCore.Web.Assignments.List.DTOs;
namespace MembershipsNetCore.Web.Assignments.List;

public class ListByFilters: Endpoint<ListAssignmentsByFiltersRequest, ListAssignmentsByFiltersResponse>
{
  private readonly IMediator _mediator;

  public ListByFilters(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(ListAssignmentsByFiltersRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(ListAssignmentsByFiltersRequest request, CancellationToken cancellationToken)
  {
    var command = new ListAssignmentQuery(request.Skip, request.Take, request.ClassId, request.TeacherId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ListAssignmentsByFiltersResponse
      {
        Assignments = result.Value.Select(
            c => new AssignmentRecord(c.Id, c.DateInit, c.DateEnd, c.TeacherId, c.TeacherName, c.ClassId, c.ClassName)
          ).ToList()
      };
    }
  }
}
