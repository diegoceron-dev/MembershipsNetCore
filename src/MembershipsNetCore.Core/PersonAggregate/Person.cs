using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.StudentAggregate;
using MembershipsNetCore.Core.TeacherAggregate;

namespace MembershipsNetCore.Core.PersonAggregate;
public class Person: EntityBase, IAggregateRoot
{
  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public int Age { get; private set; }
  public string Email { get; private set; }
  public PersonStatus Status { get; private set; } = PersonStatus.NoSet;

  // Foreign Keys
  public Student ?Student { get; private set; }
  public Teacher ?Teacher { get; private set; }

  public Person(string firstName, string lastName, int age, string email, PersonStatus? status)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    Age = Guard.Against.NegativeOrZero(age, nameof(age));
    Email = Guard.Against.NullOrEmpty(email, nameof(email));
    if (status != null) Status = status;
  }

  public void UpdatePerson(string newFirstName, string newLastName, int newAge, string newEmail, PersonStatus ?newStatus)
  {
    FirstName = Guard.Against.NullOrEmpty(newFirstName, nameof(newFirstName));
    LastName = Guard.Against.NullOrEmpty(newLastName, nameof(newLastName));
    Age = Guard.Against.NegativeOrZero(newAge, nameof(newAge));
    Email = Guard.Against.NullOrEmpty(newEmail, nameof(newEmail));
    if (newStatus != null) Status = newStatus;
  }
}
