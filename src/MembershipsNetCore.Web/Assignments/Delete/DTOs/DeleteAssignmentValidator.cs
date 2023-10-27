using FastEndpoints;
using FluentValidation;

namespace MembershipsNetCore.Web.Assignments.Delete;

public class DeleteAssignmentValidator : Validator<DeleteAssignmentRequest>
{
    public DeleteAssignmentValidator()
    {
        RuleFor(x => x.AssignmentId)
          .GreaterThan(0);
    }
}
