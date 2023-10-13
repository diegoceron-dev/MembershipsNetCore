using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Persons.Create.DTOs;

public class Request
{
  public const string Route = "/Persons";

  [Required]
  public string? FirstName { get; set; }

  [Required]
  public string? LastName { get; set; }

  [Required]
  public string? Email { get; set; }

  [Required]
  public int? Age { get; set; }
}
