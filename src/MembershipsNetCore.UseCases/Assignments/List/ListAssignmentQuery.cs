using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Assignments.List;
public record ListAssignmentQuery(int? Skip, int? Take, int? ClassId, int? TeacherId): IQuery<Result<IEnumerable<AssignmentDTO>>>;
