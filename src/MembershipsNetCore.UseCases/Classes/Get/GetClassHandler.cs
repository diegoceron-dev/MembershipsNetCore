using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.ClassAggregate;
using MembershipsNetCore.Core.ClassAggregate.Specifications;
using MembershipsNetCore.UseCases.Classes;
using MembershipsNetCore.UseCases.Classes.Get;

namespace MembershipsNetCore.UseCases.Persons.Get;

public class GetClassHandler : IQueryHandler<GetClassQuery, Result<ClassDTO>>
{
  private readonly IReadRepository<Class> _repository;

  public GetClassHandler(IReadRepository<Class> repository)
  {
    _repository = repository;
  }

  public async Task<Result<ClassDTO>> Handle(GetClassQuery request, CancellationToken cancellationToken)
  {
    var spec = new ClassByIdSpec(request.ClassId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity == null) return Result.NotFound();

    return new ClassDTO(entity.Id, entity.Name, entity.Status);
  }
}
