using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Dto
{
    public class EmployeeSalaryDto
    {
        public string EmployeeName { get; set; }
        public DateTime EmployeeEnteredDate { get; set; }
        public int EmployeeId { get; set; }
        public double BaseSalary { get; set; }
        public double BonusRate { get; set; } = 1.0;
        public DateTime ValidAfter { get; set; }
        public DateTime ValidBefore { get; set; }
    }
}
