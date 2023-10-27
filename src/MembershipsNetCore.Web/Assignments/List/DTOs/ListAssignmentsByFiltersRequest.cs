using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Assignments.List.DTOs;

public class ListAssignmentsByFiltersRequest
{
  public const string Route = "/Assignments";

  public int? TeacherId { get; set; }

  public int? ClassId { get; set; }

  public int? Skip { get; set; }

  public int? Take { get; set; }
}
