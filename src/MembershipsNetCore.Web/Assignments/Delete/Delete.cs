using FastEndpoints;
using Ardalis.Result;
using MediatR;
using MembershipsNetCore.UseCases.Assignments.Delete;

namespace MembershipsNetCore.Web.Assignments.Delete;

public class Delete : Endpoint<DeleteAssignmentRequest>
{
  private readonly IMediator _mediator;

  public Delete(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteAssignmentRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
   DeleteAssignmentRequest request,
   CancellationToken cancellationToken
   )
  {
    var command = new DeleteAsssignmentCommand(request.AssignmentId);
    
    var result = await _mediator.Send(command);
    
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
  }
}
