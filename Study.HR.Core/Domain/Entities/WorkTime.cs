﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 근무시간. 월단위로 관리한다.
    /// </summary>
    public class WorkTime : Entity
    {
        public int Month { get; private set; }
        public int MinutesWorked { get; private set; }

        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;
    }
}
