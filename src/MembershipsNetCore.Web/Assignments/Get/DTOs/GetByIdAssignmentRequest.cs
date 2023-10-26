namespace MembershipsNetCore.Web.Assignments.Get.DTOs;

public class GetByIdAssignmentRequest
{
  public const string Route = "/Assignments/{AssignmentId:int}";
  public static string BuildRoute(int assignmentId) => Route.Replace("{AssignmentId:int}", assignmentId.ToString());
  public int AssignmentId { get; set; }
}
