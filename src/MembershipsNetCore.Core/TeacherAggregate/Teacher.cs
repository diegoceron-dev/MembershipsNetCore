using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.PersonAggregate;

namespace MembershipsNetCore.Core.TeacherAggregate;
public class Teacher : EntityBase, IAggregateRoot
{
  // Foreign Keys

  [ForeignKey("PersonId")]
  public Person ?person { get; private set; }
  public int PersonId { get; private set; }

  public Teacher(int personId)
  {
    PersonId = Guard.Against.NegativeOrZero(personId, nameof(personId));
  }
}
