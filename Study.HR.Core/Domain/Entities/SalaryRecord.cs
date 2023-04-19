using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    public class SalaryRecord : Entity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Month { get; set; }
        public int WorkTimeId { get; set; }
        public WorkTime WorkTime { get; set; }
        public int MinutesWorked { get; set; }
        public int EmployeeSalaryId { get; set; }
        public EmployeeSalary EmployeeSalary { get; set; }
        public double BaseSalary { get; set; }
        public double BonusRate { get; set; } = 1.0;
    }
}
