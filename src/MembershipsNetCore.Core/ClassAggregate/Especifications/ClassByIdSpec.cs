using Ardalis.Specification;

namespace MembershipsNetCore.Core.ClassAggregate.Specifications;
public class ClassByIdSpec : Specification<Class>
{
  public ClassByIdSpec(int classId)
  {
    Query.Where(classs => classs.Id == classId);
  }
}
