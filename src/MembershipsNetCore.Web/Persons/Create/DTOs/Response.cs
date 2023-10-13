namespace MembershipsNetCore.Web.Persons.Create.DTOs;

public class Response
{
  public Response(int id, string firstName, string lastName)
  {
    Id = id;
    FullName = $"{firstName} {lastName}";
  }
  public int Id { get; set; }
  public string FullName { get; set; }
}
