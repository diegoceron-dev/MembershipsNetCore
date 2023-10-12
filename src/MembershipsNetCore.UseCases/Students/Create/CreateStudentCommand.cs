using Ardalis.Result;

namespace MembershipsNetCore.UseCases.Students.Create;
public record CreateStudentCommand(int idPerson) : Ardalis.SharedKernel.ICommand<Result<int>>;
