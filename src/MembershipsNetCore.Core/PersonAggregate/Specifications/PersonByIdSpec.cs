using Ardalis.Specification;

namespace MembershipsNetCore.Core.PersonAggregate.Specifications;
public class PersonByIdSpec: Specification<Person>
{
  public PersonByIdSpec(int personId)
  {
    Query.Where(person => person.Id == personId).Include(t => t.Teacher).Include(s => s.Student);
  }
}
