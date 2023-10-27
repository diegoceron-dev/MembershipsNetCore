using Ardalis.Specification;

namespace MembershipsNetCore.Core.AssignmentAggregate.Specifications;

public class AssignmentByFiltersSpec : Specification<Assignment>
{
  public AssignmentByFiltersSpec(int? Skip, int? Take, int? teacherId, int? classId)
  {
    Query
      .Include(assignment => assignment.Class)
      .Include(assignment => assignment.Teacher)
      .Include(assignment => assignment!.Teacher!.Person);

    if (teacherId != null)
    {
      Query
        .Where(assignment => teacherId != null && assignment.TeacherId == teacherId);
    }

    if (classId != null)
    {
      Query
        .Where(assignment => classId != null && assignment.ClassId == classId);
    }
  }
}

