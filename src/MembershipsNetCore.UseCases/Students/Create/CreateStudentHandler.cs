using Ardalis.Result;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.StudentAggregate;

namespace MembershipsNetCore.UseCases.Students.Create;
public class CreateStudentHandler : ICommandHandler<CreateStudentCommand, Result<int>>
{
  private readonly IRepository<Student> _repository;
  public CreateStudentHandler(IRepository<Student> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
  {
    var newStudent = new Student(request.idPerson);

    var createdItem = await _repository.AddAsync(newStudent, cancellationToken);

    return createdItem.Id;
  }
}
