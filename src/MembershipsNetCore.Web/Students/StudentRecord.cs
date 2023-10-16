using MembershipsNetCore.Web.Endpoints.PersonEndpoints;

namespace MembershipsNetCore.Web.Endpoints.StudentEndpoints.DTOs;

public record StudentRecord(int Id, PersonRecord person);
