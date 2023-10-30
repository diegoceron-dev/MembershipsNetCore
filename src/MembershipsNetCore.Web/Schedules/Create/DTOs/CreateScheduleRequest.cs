using System.ComponentModel.DataAnnotations;
using MembershipsNetCore.UseCases.Schedules.Create;

namespace MembershipsNetCore.Web.Schedules.Create.DTOs;

public class CreateScheduleRequest
{
  public const string Route = "/Schedules";

  [Required]
  public required List<ScheduleItem> schedules { get; set; }
}
