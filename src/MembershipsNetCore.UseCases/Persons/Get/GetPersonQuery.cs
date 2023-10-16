using Ardalis.Result;
using Ardalis.SharedKernel;

namespace MembershipsNetCore.UseCases.Persons.Get;

public record GetPersonQuery(int PersonId) : IQuery<Result<PersonDTO>>;
