using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Assignments.Delete;

public record DeleteAsssignmentCommand(int AssignmentId) : ICommand<Result>;
