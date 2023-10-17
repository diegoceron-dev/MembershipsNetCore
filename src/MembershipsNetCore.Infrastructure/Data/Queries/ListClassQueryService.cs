using System.Linq;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.ClassAggregate;
using MembershipsNetCore.UseCases.Classes;
using MembershipsNetCore.UseCases.Classes.List;

namespace MembershipsNetCore.Infrastructure.Data.Queries;
public class ListClassQueryService : IListClassesQueryService
{
  private readonly IReadRepository<Class> _repository;

  public ListClassQueryService(IReadRepository<Class> repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<ClassDTO>> ListAsync()
  {
    var entity = (await (_repository).ListAsync()).Select(c => new ClassDTO(c.Id, c.Name, c.Status));

    if (entity == null) return Enumerable.Empty<ClassDTO>();

    return entity;
  }
}
