using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.Core.ClassAggregate;
public class Class: EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public ClassStatus Status { get; private set; } = ClassStatus.NoSet;

  public Class(string name, ClassStatus? status)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    if (status != null) Status = status;
  }

  public void UpdateClass(string newName,  ClassStatus ?newStatus)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    if (newStatus != null) Status = newStatus;
  }
}
