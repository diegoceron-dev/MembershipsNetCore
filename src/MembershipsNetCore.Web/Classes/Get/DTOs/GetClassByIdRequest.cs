namespace MembershipsNetCore.Web.Endpoints.ClassEndpoints.Get.DTOs;

public class GetClassByIdRequest
{
  public const string Route = "/Classes/{ClassId:int}";
  public static string BuildRoute(int classId) => Route.Replace("{ClassId:int}", classId.ToString());
  public int ClassId { get; set; }
}
