using MembershipsNetCore.Web.Classes;

namespace MembershipsNetCore.Web.Endpoints.ClassEndpoints.Get.DTOs;

public class ListClassResponse
{
  public List<ClassRecord> Classes { get; set; } = new();
}
