using Ardalis.Result;

namespace MembershipsNetCore.UseCases.Teachers.Create;
public record CreateTeacherCommand(int idPerson): Ardalis.SharedKernel.ICommand<Result<int>>;
