using FastEndpoints;
using MediatR;
using Ardalis.Result;
using MembershipsNetCore.Web.Endpoints.ContributorEndpoints;
using MembershipsNetCore.UseCases.Contributors.Get;

namespace MembershipsNetCore.Web.ContributorEndpoints;

public class GetById // : Endpoint<GetContributorByIdRequest, ContributorRecord>
{
  //private readonly IMediator _mediator;

  //public GetById(IMediator mediator)
  //{
  //  _mediator = mediator;
  //}

  //public override void Configure()
  //{
  //  Get(GetContributorByIdRequest.Route);
  //  AllowAnonymous();
  //}

  //public override async Task HandleAsync(GetContributorByIdRequest request,
  //  CancellationToken cancellationToken)
  //{
  //  var command = new GetContributorQuery(request.ContributorId);

  //  var result = await _mediator.Send(command);

  //  if (result.Status == ResultStatus.NotFound)
  //  {
  //    await SendNotFoundAsync(cancellationToken);
  //    return;
  //  }

  //  if (result.IsSuccess)
  //  {
  //    Response = new ContributorRecord(result.Value.Id, result.Value.Name);
  //  }
  //}
}
