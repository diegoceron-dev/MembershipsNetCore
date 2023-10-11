using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.PersonAggregate;

namespace MembershipsNetCore.UseCases.Persons.Create;

public class CreatePersonHandler : ICommandHandler<CreatePersonCommand, Result<int>>
{
  private readonly IRepository<Person> _repository;

  public CreatePersonHandler(IRepository<Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
  {
    var newPerson = new Person(request.firstName, request.lastName, request.age, request.email, request.status);

    var createdItem = await _repository.AddAsync(newPerson, cancellationToken);

    return createdItem.Id;
  }
}
