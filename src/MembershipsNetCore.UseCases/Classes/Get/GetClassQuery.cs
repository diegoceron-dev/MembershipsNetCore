using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Classes.Get;

public record GetClassQuery(int ClassId) : IQuery<Result<ClassDTO>>;
