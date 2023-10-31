using Ardalis.Specification;
using MembershipsNetCore.Core.AssignmentAggregate;

namespace MembershipsNetCore.Core.ScheduleAggregate.Specifications;
public class SchedulesByFiltersSpec : Specification<Schedule>
{
  public SchedulesByFiltersSpec(int? Skip, int? Take, int? teacherId, int? classId, int? scheduleId, int? assignmentId)
  {
    Query
    .Include(schedule => schedule.Assignment)
    .Include(schedule => schedule.Assignment!.Teacher)
    .Include(schedule => schedule!.Assignment!.Teacher!.Person)
    .Include(schedule => schedule!.Assignment!.Class);

    if (teacherId != null)
    {
      Query
        .Where(schedule => schedule.Assignment!.TeacherId == teacherId);
    }

    if (classId != null)
    {
      Query
        .Where(schedule => schedule.Assignment!.ClassId == classId);
    }

    if (scheduleId != null)
    {
      Query
        .Where(schedule => schedule.Id == scheduleId);
    }

    if (assignmentId != null)
    {
      Query.Where(schedule => schedule.AssignmentId == assignmentId);
    }

  }

}
