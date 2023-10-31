using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Schedules.List.DTOs;

public class ListScheduleRequest
{

  public const string Route = "/Schedules";

  [Required]
  public int? TeacherId { get; set; }

  [Required]
  public int? ClassId { get; set; }

  [Required]
  public int? AssignmentId { get; set; }

  [Required]
  public int? ScheduleId { get; set; }

  [Required]
  public int? Skip { get; set; }

  [Required]
  public int? Take { get; set; }

}
