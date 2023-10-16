using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.TeacherAggregate;
using MembershipsNetCore.Core.TeacherAggregate.Specifications;

namespace MembershipsNetCore.UseCases.Teachers.Get;
public class GetTeacherHandler: IQueryHandler<GetTeacherQuery, Result<TeacherDTO>>
{
  private readonly IReadRepository<Teacher> _repository;

  public GetTeacherHandler(IReadRepository<Teacher> repository)
  {
    _repository = repository;
  }

  public async Task<Result<TeacherDTO>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
  {
    var spec = new TeacherByIdSpec(request.TeacherId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new TeacherDTO(entity.Id, entity.PersonId);
  }
}
