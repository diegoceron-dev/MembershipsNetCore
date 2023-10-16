using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;

public class Request
{
  public const string Route = "/Students";

  [Required]
  public string? FirstName { get; set; }

  [Required]
  public string? LastName { get; set; }

  [Required]
  public string? Email { get; set; }

  [Required]
  public int? Age { get; set; }
}
