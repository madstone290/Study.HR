using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 직책
    /// </summary>
    public class JobRole : Entity
    {
        protected JobRole() { }
        public JobRole(string code, string name)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            ThrowIf(string.IsNullOrWhiteSpace(code), "Code is empty");

            Name = name;
            Code = code;
        }

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
