using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.AssignmentAggregate;
using MembershipsNetCore.Core.AssignmentAggregate.Specifications;

namespace MembershipsNetCore.UseCases.Assignments.Get;

public class GetAssignmentHandler : IQueryHandler<GetAssignmentQuery, Result<AssignmentDTO>>
{
  private readonly IReadRepository<Assignment> _repository;

  public GetAssignmentHandler(IReadRepository<Assignment> repository)
  {
    _repository = repository;
  }

  public async Task<Result<AssignmentDTO>> Handle(GetAssignmentQuery request, CancellationToken cancellationToken)
  {
    var spec = new AssignmentByIdSpec(request.AssignmentId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity == null) return Result.NotFound();

    var nameTeacher = entity.Teacher?.Person?.FirstName!;
    var clasName = entity.Class?.Name!;

    return new AssignmentDTO(entity.Id, (DateTimeOffset)entity.DateInit!, (DateTimeOffset)entity.DateEnd!, entity.TeacherId, nameTeacher, entity.ClassId, clasName);
  }
}
