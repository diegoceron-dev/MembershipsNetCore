using Ardalis.Result;

namespace MembershipsNetCore.UseCases.Assignments.Create;
public record CreateAssignmentCommand(DateTimeOffset? DateInit, DateTimeOffset? DateEnd, int TeacherId, int ClassId) : Ardalis.SharedKernel.ICommand<Result<int>>;
