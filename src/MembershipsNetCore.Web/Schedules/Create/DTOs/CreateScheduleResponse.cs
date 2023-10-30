using MembershipsNetCore.UseCases.Schedules.Create;

namespace MembershipsNetCore.Web.Schedules.Create.DTOs;

public class CreateScheduleResponse
{
  public CreateScheduleResponse(List<int> schedules) {
    Schedules = schedules;
  }

  public List<int> Schedules { get; set; }
}
