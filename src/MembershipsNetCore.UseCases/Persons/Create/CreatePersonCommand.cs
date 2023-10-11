using Ardalis.Result;
using MembershipsNetCore.Core.PersonAggregate;

namespace MembershipsNetCore.UseCases.Persons.Create;

public record CreatePersonCommand(string firstName, string lastName, int age, string email, PersonStatus? status) : Ardalis.SharedKernel.ICommand<Result<int>>;
