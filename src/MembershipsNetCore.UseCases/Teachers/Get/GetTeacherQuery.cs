using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Teachers.Get;

public record GetTeacherQuery(int TeacherId): IQuery<Result<TeacherDTO>>;
