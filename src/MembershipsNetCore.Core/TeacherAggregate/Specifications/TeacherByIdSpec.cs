using Ardalis.Specification;

namespace MembershipsNetCore.Core.TeacherAggregate.Specifications;
public class TeacherByIdSpec: Specification<Teacher>
{
  public TeacherByIdSpec(int teacherId) 
  {
    Query.Where(teacher => teacher.Id == teacherId)
           .Include(teacher => teacher.Person);
  }
}
