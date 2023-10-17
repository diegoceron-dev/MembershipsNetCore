using Ardalis.Result;
using MembershipsNetCore.Core.ClassAggregate;

namespace MembershipsNetCore.UseCases.Classes.Create;

public record CreateClassCommand(string Name, ClassStatus ?status) : Ardalis.SharedKernel.ICommand<Result<int>>;
