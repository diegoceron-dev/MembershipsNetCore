using MembershipsNetCore.Core.ClassAggregate;

namespace MembershipsNetCore.UseCases.Classes;
public record ClassDTO(int Id, string Name, ClassStatus ?Status);
