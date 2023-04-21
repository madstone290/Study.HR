using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 급여 기본정보. 사용자당 하나씩 가진다.
    /// </summary>
    public class PayProfile : Entity
    {
        public string? SalaryType { get; private set; }
        public double BaseSalary { get; private set; }
        public string? SalaryCurrency { get; private set; }
        public double BonusRate { get; private set; } = 1.0;

        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;
    }
}
