using Study.HR.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Dto
{
    public class PayrollDto
    {
        public int Month { get; init; }

        public int MinutesWorked { get; init; }

        public double BaseSalary { get; init; }

        public double BonusRate { get; init; } = 1.0;

        public int EmployeeId { get; init; }
        public string EmployeeName { get; init; } = string.Empty;
        public string EmployeeCode { get; init; } = string.Empty;

        public int? WorkTimeId { get; init; }

        public int? PayProfileId { get; init; }
    }
}
