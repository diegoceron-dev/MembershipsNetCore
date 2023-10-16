namespace MembershipsNetCore.Web.Teachers.Get.DTOs;

public class GetTeacherByIdRequest
{
  public const string Route = "/Teachers/{TeacherId:int}";

  public static string BuildRoute(int teacherId) => Route.Replace("{TeacherId:int}", teacherId.ToString());

  public int TeacherId { get; set; }
}
