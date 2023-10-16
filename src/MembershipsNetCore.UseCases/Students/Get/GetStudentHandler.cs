using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.StudentAggregate;
using MembershipsNetCore.Core.StudentAggregate.Specifications;

namespace MembershipsNetCore.UseCases.Students.Get;

public class GetStudentHandler : IQueryHandler<GetStudentQuery, Result<StudentDTO>>
{
  private readonly IReadRepository<Student> _repository;

  public GetStudentHandler(IReadRepository<Student> repository)
  {
    _repository = repository;
  }

  public async Task<Result<StudentDTO>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
  {
    var spec = new StudentByIdSpec(request.StudentId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new StudentDTO(entity.Id, entity.PersonId);
  }
}
