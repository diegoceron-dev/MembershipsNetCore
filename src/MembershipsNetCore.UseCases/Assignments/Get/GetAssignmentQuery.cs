using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Assignments.Get;
public record GetAssignmentQuery (int AssignmentId): IQuery<Result<AssignmentDTO>>;
