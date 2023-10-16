using Ardalis.Specification;

namespace MembershipsNetCore.Core.StudentAggregate.Specifications;

public class StudentByIdSpec : Specification<Student>
{
  public StudentByIdSpec(int studentId)
  {
    Query
        .Where(student => student.Id == studentId);
  }
}
