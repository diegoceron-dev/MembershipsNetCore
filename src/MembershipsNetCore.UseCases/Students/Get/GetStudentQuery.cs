using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Students.Get;

public record GetStudentQuery(int StudentId) : IQuery<Result<StudentDTO>>;
