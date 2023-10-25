using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using MembershipsNetCore.Core.ClassAggregate;
using MembershipsNetCore.Core.TeacherAggregate;

namespace MembershipsNetCore.Core.AssignmentAggregate;
public class Assignment : EntityBase, IAggregateRoot
{
  public DateTimeOffset? DateInit { get; private set; }
  public DateTimeOffset? DateEnd { get; private set; }

  [ForeignKey("TeacherId")]
  public Teacher? Teacher { get; private set; }
  public int TeacherId { get; private set; }

  [ForeignKey("ClassId")]
  public Class? Class { get; private set; }
  public int ClassId { get; private set; }

  public Assignment(DateTimeOffset? dateInit, DateTimeOffset? dateEnd, int teacherId, int classId)
  {

    DateInit = Guard.Against.Null(dateInit, nameof(dateInit));
    DateEnd = Guard.Against.Null(dateEnd, nameof(dateEnd));
    TeacherId = Guard.Against.NegativeOrZero(teacherId, nameof(teacherId));
    ClassId = Guard.Against.NegativeOrZero(classId, nameof(classId));
  }

  public void UpdateAssignment(DateTime dateInit, DateTime dateEnd, int teacherId, int classId)
  {
    DateInit = Guard.Against.NullOrOutOfSQLDateRange(dateInit, nameof(dateInit));
    DateEnd = Guard.Against.NullOrOutOfSQLDateRange(dateEnd, nameof(dateEnd));
    TeacherId = Guard.Against.NegativeOrZero(teacherId, nameof(teacherId));
    TeacherId = Guard.Against.NegativeOrZero(classId, nameof(classId));
  }


}
