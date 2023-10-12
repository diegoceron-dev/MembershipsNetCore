namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;

public class Response
{
  public Response(int id, int idPerson) {
    IdStudent = id;
    IdPerson = idPerson;
  }

  public int IdStudent { get; set; }

  public int IdPerson { get; set; }
}
