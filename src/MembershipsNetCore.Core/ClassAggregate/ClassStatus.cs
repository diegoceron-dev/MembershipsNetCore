using Ardalis.SmartEnum;
namespace MembershipsNetCore.Core.ClassAggregate;
public class ClassStatus : SmartEnum<ClassStatus>
{

  public static readonly ClassStatus NoSet = new(nameof(Active), 0);

  public static readonly ClassStatus Active = new(nameof(Active), 1);

  public static readonly ClassStatus Inactive = new(nameof(Active), 2);

  protected ClassStatus(string name, int value) : base(name, value) { }

}
