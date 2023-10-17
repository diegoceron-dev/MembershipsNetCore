namespace MembershipsNetCore.UseCases.Classes.List;

  public interface IListClassesQueryService
  {
    Task<IEnumerable<ClassDTO>> ListAsync();
  }

