using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.PersonAggregate;

namespace MembershipsNetCore.Core.StudentAggregate;
public class Student: EntityBase, IAggregateRoot
{
  [ForeignKey("PersonId")]
  public Person? Person { get; private set; }
  public int PersonId { get; private set; }

  public Student(int personId)
  {
    PersonId = Guard.Against.NegativeOrZero(personId, nameof(personId));
  }
}
