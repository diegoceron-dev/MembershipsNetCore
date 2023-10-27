namespace MembershipsNetCore.Web.Assignments.Delete;

 public record DeleteAssignmentRequest
 {
     public const string Route = "/Assignments/{AssignmentId:int}";
     public static string BuildRoute(int assignmentId) => Route.Replace("{AssignmentId:int}", assignmentId.ToString());
     public int AssignmentId { get; set; }
 }
