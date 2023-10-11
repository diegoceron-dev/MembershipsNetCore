using Ardalis.SmartEnum;
namespace MembershipsNetCore.Core.PersonAggregate;
public class PersonStatus: SmartEnum<PersonStatus>
{

  public static readonly PersonStatus NoSet = new(nameof(Active), 0);

  public static readonly PersonStatus Active = new(nameof(Active), 1);

  public static readonly PersonStatus Inactive = new(nameof(Active), 2);

  protected PersonStatus(string name, int value) : base(name, value) { }

}
