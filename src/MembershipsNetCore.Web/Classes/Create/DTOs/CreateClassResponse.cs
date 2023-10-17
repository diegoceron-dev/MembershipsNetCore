namespace MembershipsNetCore.Web.Classes.Create.DTOs;

public class CreateClassResponse
{
  public CreateClassResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }

  public int Id { get; set; }
  public string Name { get; set; }
}
