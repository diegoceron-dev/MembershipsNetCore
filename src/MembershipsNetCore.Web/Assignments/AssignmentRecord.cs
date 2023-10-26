namespace MembershipsNetCore.Web.Assignments;

public record AssignmentRecord(int Id, DateTimeOffset DateInit, DateTimeOffset DateEnd, int IdTeacher, string TeacherName, int IdClass, string ClassName);
