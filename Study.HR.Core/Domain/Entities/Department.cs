﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 부서
    /// </summary>
    public class Department
    {
        public int UpperDepartmentId { get; private set; }
        
        /// <summary>
        /// 상위 부서
        /// </summary>
        public Department? UpperDepartment { get; private set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; private set; } = string.Empty;


    }
}
