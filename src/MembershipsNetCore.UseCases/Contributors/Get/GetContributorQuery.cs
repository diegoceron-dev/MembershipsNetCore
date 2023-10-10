using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
