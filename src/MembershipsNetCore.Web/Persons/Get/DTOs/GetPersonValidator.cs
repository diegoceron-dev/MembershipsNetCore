using FastEndpoints;
using FluentValidation;

namespace MembershipsNetCore.Web.Endpoints.PersonEndpoints.DTOs;

public class GetPersonValidator : Validator<GetPersonByIdRequest>
{
  public GetPersonValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
