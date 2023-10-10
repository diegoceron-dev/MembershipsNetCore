using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
