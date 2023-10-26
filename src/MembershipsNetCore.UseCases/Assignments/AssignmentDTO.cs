namespace MembershipsNetCore.UseCases.Assignments;
public record AssignmentDTO(int Id, DateTimeOffset DateInit, DateTimeOffset DateEnd, int TeacherId, string TeacherName, int ClassId, string ClassName);
