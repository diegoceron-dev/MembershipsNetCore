using MembershipsNetCore.Web.Endpoints.PersonEndpoints;

namespace MembershipsNetCore.Web.Endpoints.TeacherEndpoints.DTOs;

public record TeacherRecord(int Id, PersonRecord Person);
