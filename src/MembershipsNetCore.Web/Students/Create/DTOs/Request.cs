using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;

public class Request
{
  public const string Route = "/Students";

  [Required]
  public int ?IdPerson { get; set; }
}
