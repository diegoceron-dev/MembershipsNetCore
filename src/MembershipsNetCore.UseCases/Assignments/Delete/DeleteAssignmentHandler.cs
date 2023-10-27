using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using MembershipsNetCore.Core.AssignmentAggregate;
using MembershipsNetCore.Core.AssignmentAggregate.Specifications;
// using MembershipsNetCore.Core.Interfaces;

namespace MembershipsNetCore.UseCases.Assignments.Delete;

public class DeleteAssignmentHandler : ICommandHandler<DeleteAsssignmentCommand, Result>
{
  private readonly IRepository<Assignment> _repository;
   
  public DeleteAssignmentHandler(IRepository<Assignment> repository)
  {
    _repository = repository;
  }

  public async Task<Result> Handle(DeleteAsssignmentCommand request, CancellationToken cancellationToken)
  {
    var specById = new AssignmentByIdSpec(request.AssignmentId);

    var entityToDelete = await _repository.FirstOrDefaultAsync(specById, cancellationToken);

    if (entityToDelete == null) return Result.NotFound();
    
    await _repository.DeleteAsync(entityToDelete, cancellationToken);

    return Result.Success();
  }
}
