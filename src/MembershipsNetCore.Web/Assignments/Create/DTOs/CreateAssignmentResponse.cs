namespace MembershipsNetCore.Web.Assignments.Create.DTOs;

public class CreateAssignmentResponse
{
  public CreateAssignmentResponse(int id, DateTimeOffset? dateInit, DateTimeOffset? dateEnd, int teacherId, int classId ) {
    Id = id;
    if(dateInit != null) DateInit = dateInit;
    if (dateEnd != null) DateEnd = dateEnd;
    TeacherId = teacherId;
    ClassId = classId;
  }

  public int Id { get; set; }

  public DateTimeOffset? DateInit { get; set; }

  public DateTimeOffset? DateEnd { get; set; }

  public int TeacherId { get; set; }

  // public string NameTeacher { get; set; }

  public int ClassId { get; set; }
  
  //public string NameClass { get; set; }

}
