using MembershipsNetCore.Core.PersonAggregate;

namespace MembershipsNetCore.Web.Endpoints.PersonEndpoints;

public record PersonRecord(int Id, string FirstName, string LastName, int Age, string Email, PersonStatus status);
