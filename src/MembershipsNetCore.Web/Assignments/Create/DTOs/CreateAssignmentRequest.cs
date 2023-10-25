using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Assignments.Create.DTOs;

public class CreateAssignmentRequest
{
  public const string Route = "/Assignments";

  [Required]
  public string? DateInit { get; set; }

  [Required]
  public string? DateEnd { get; set; }

  [Required]
  public int TeacherId { get; set; }

  [Required]
  public int ClassId { get; set; }
}
