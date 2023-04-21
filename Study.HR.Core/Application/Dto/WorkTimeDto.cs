using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Dto
{
    public class WorkTimeDto
    {
        public int Month { get; private set; }
        public int MinutesWorked { get; private set; }

        public int EmployeeId { get; private set; }
        public string EmployeeName { get; init; } = string.Empty;
        public string EmployeeCode { get; init; } = string.Empty;
    }
}
