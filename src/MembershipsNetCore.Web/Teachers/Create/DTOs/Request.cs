using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;

public class Request
{
  public const string Route = "/Teachers";

  [Required]
  public string? FirstName { get; set; }

  [Required]
  public string? LastName { get; set; }

  [Required]
  public string? Email { get; set; }

  [Required]
  public int? Age { get; set; }
}
