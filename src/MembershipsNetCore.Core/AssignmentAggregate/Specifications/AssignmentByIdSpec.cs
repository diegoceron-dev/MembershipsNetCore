using Ardalis.Specification;

namespace MembershipsNetCore.Core.AssignmentAggregate.Specifications;
public class AssignmentByIdSpec : Specification<Assignment>
{
  public AssignmentByIdSpec(int assignmentId)
  {
    Query
      .Where(assignment => assignment.Id == assignmentId)
      .Include(assignment => assignment.Class)
      .Include(assignment => assignment.Teacher)
      .Include(a => a!.Teacher!.Person);
  }
}
