using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Dto
{
    public class PayProfileDto
    {
        public string? SalaryType { get; init; }
        public double BaseSalary { get; init; }
        public string? SalaryCurrency { get; init; }
        public double BonusRate { get; init; } = 1.0;

        public int EmployeeId { get; init; }
    }
}
