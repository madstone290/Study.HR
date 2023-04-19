using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    public class WorkTime : Entity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Month { get; set; }
        public int MinutesWorked { get; set; }
    }
}
