namespace MembershipsNetCore.Web.Assignments.List.DTOs;

public class ListAssignmentsByFiltersResponse
{
  public List<AssignmentRecord> Assignments { get; set; } = new();
}
