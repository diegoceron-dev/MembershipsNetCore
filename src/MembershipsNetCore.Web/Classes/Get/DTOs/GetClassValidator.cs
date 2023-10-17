using FastEndpoints;
using FluentValidation;

namespace MembershipsNetCore.Web.Endpoints.ClassEndpoints.Get.DTOs;

public class GetClassValidator : Validator<GetClassByIdRequest>
{
  public GetClassValidator()
  {
    RuleFor(x => x.ClassId)
    .GreaterThan(0);
  }
}
