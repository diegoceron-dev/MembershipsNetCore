using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.ClassAggregate;

namespace MembershipsNetCore.UseCases.Classes.Create;

public class CreateClassHandler : ICommandHandler<CreateClassCommand, Result<int>>
{
  private readonly IRepository<Class> _repository;

  public CreateClassHandler(IRepository<Class> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(CreateClassCommand request, CancellationToken cancellationToken)
  {
    var newClass = new Class(request.Name, request.status);

    var createdItem = await _repository.AddAsync(newClass, cancellationToken);

    return createdItem.Id;
  }
}
