namespace MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;

public class Response
{
  public Response(int id, int idPerson)
  {
    IdTeacher = id;
    IdPerson = idPerson;
  }

  public int IdTeacher { get; set; }

  public int IdPerson { get; set; }
}
