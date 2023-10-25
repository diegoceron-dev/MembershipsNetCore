using Ardalis.Specification;

namespace MembershipsNetCore.Core.AssignmentAggregate.Specifications;
public class AssignmentByIdSpec : Specification<Assignment>
{
  public AssignmentByIdSpec(int assignmentId)
  {
    Query
      .Include(assignment => assignment.Teacher)
      .Include(assignment => assignment.Class)
      .Where(assignment => assignment.Id == assignmentId);
  }
}
