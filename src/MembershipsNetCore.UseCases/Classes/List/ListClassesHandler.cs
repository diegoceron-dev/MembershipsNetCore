using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Classes.List;
public class ListClassesHandler : IQueryHandler<ListClassesQuery, Result<IEnumerable<ClassDTO>>>
{
  private readonly IListClassesQueryService _query;

  public ListClassesHandler(IListClassesQueryService query)
  {
    _query = query;
  }

  public async Task<Result<IEnumerable<ClassDTO>>> Handle(ListClassesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
