using Ardalis.Specification;

namespace MembershipsNetCore.Core.AssignmentAggregate.Specifications;

public class AssignmentByFiltersSpec : Specification<Assignment>
{
  public AssignmentByFiltersSpec(int? Skip, int? Take, int? teacherId, int? classId)
  {
    Query
      .Include(assignment => assignment.Class)
      .Include(assignment => assignment.Teacher)
      .Include(assignment => assignment!.Teacher!.Person) 
      .Where(assignment => teacherId != null && assignment.TeacherId == teacherId)
      .Where(assignment => classId != null && assignment.ClassId == classId);
  }
}

