namespace MembershipsNetCore.Web.Assignments;

public record AssignmentRecord(int Id, DateTime DateInit, DateTime DateEnd, int IdTeacher, string TeacherName, int IdClass, string ClassName);
