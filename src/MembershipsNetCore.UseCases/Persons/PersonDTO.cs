using MembershipsNetCore.Core.PersonAggregate;

namespace MembershipsNetCore.UseCases.Persons;
public record PersonDTO(int Id, string FirstName, string LastName, int Age, string Email, PersonStatus Status);
