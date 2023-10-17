using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Classes.List;
public record ListClassesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ClassDTO>>>;
