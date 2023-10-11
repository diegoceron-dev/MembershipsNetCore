using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MembershipsNetCore.Web.Endpoints.PersonEndpoints;

public class CreatePersonResponse
{
  public CreatePersonResponse(int id, string firstName, string lastName)
  {
    Id = id;
    FullName = $"{firstName} {lastName}";
  }
  public int Id { get; set; }
  public string FullName { get; set; }
}
