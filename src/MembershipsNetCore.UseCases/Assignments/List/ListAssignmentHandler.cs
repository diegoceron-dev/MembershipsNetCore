using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.AssignmentAggregate;
using MembershipsNetCore.Core.AssignmentAggregate.Specifications;

namespace MembershipsNetCore.UseCases.Assignments.List;
public class ListAssignmentHandler : IQueryHandler<ListAssignmentQuery, Result<IEnumerable<AssignmentDTO>>>
{
  private readonly IReadRepository<Assignment> _repository;

  public ListAssignmentHandler(IReadRepository<Assignment> repository)
  {
    _repository = repository;
  }

  public async Task<Result<IEnumerable<AssignmentDTO>>> Handle(ListAssignmentQuery request, CancellationToken cancellationToken)
  {
    var spec = new AssignmentByFiltersSpec(null, null, request.TeacherId, request.ClassId);

    var entity = (await (_repository).ListAsync(spec, cancellationToken))
      .Select(a => new AssignmentDTO(a.Id, (DateTimeOffset)a.DateInit!, (DateTimeOffset)a.DateEnd!, a.TeacherId, a.Teacher?.Person?.FirstName!, a.ClassId, a.Class?.Name!));

    if (entity == null) return Result.NotFound();
  
    return Result.Success(entity);
  }
}
