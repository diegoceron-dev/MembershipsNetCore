﻿using System.ComponentModel.DataAnnotations;

namespace MembershipsNetCore.Web.Assignments.List.DTOs;

public class ListAssignmentsByFiltersRequest
{
  public const string Route = "/Assignments";

  [Required]
  public int? TeacherId { get; set; }

  [Required]
  public int? ClassId { get; set; }

  [Required]
  public int? Skip { get; set; }

  [Required]
  public int? Take { get; set; }
}
