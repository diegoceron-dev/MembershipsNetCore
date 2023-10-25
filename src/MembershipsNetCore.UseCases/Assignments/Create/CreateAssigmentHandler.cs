using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.AssignmentAggregate;

namespace MembershipsNetCore.UseCases.Assignments.Create;

public class CreateAssigmentHandler : ICommandHandler<CreateAssignmentCommand, Result<int>>
{
  private readonly IRepository<Assignment> _repository;

  public CreateAssigmentHandler(IRepository<Assignment> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
  {
    var newClass = new Assignment(request.DateInit!, request.DateEnd!, request.TeacherId, request.ClassId);
     
    var createdItem = await _repository.AddAsync(newClass, cancellationToken);

    return createdItem.Id;
  }
}
