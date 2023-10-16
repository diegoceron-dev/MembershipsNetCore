using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.PersonAggregate;
using MembershipsNetCore.Core.PersonAggregate.Specifications;

namespace MembershipsNetCore.UseCases.Persons.Get;

public class GetStudentHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
  private readonly IReadRepository<Person> _repository;

  public GetStudentHandler(IReadRepository<Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpec(request.PersonId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    
    if (entity == null) return Result.NotFound();

    return new PersonDTO(entity.Id, entity.FirstName, entity.LastName, entity.Age, entity.Email, entity.Status);
  }
}
