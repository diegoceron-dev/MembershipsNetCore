namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;

public class GetStudentByIdRequest
{
  public const string Route = "/Students/{StudentId:int}";

  public static string BuildRoute(int studentId) => Route.Replace("{StudentId:int}", studentId.ToString());

  public int StudentId { get; set; }
}
