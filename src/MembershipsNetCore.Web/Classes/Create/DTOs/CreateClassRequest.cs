using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Classes.Create.DTOs;

public class CreateClassRequest
{
  public const string Route = "/Classes";

  [Required]
  public string? Name { get; set; }
}
