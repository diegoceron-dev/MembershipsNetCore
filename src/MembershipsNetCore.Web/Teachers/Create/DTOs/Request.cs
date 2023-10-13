using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;

public class Request
{
  public const string Route = "/Teachers";

  [Required]
  public int? IdPerson { get; set; }
}
