using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    public class EmployeeDetail : Entity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        

        public string? Desc { get; set; }
        public int Rate { get; set; }


    }
}
