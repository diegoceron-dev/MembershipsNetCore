using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipsNetCore.UseCases.Assignments;
public record AssignmentDTO(int Id, DateTime DateInit, DateTime DateEnd, int TeacherId, int ClassId);
