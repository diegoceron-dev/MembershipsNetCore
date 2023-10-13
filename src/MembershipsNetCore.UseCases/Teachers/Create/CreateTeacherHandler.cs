using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.TeacherAggregate;

namespace MembershipsNetCore.UseCases.Teachers.Create;
public class CreateTeacherHandler : ICommandHandler<CreateTeacherCommand, Result<int>>
{
  private readonly IRepository<Teacher> _repository;

  public CreateTeacherHandler(IRepository<Teacher> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
  {
    var newTeacher = new Teacher(request.idPerson);

    var createdItem = await _repository.AddAsync(newTeacher, cancellationToken);

    return createdItem.Id;
  }
}
