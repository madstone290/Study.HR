using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 급여 지급서
    /// </summary>
    public class Payroll : Entity
    {
        public int Month { get; private set; }
        
        public int MinutesWorked { get; private set; }
     
        public double BaseSalary { get; private set; }
        
        public double BonusRate { get; private set; } = 1.0;

        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public int? WorkTimeId { get; private set; }
        public WorkTime? WorkTime { get; private set; }

        public int? PayProfileId { get; private set; }
        public PayProfile? PayProfile { get; private set; }
    }
}
