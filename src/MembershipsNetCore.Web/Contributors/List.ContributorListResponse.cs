using MembershipsNetCore.Web.ContributorEndpoints;

namespace MembershipsNetCore.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}
