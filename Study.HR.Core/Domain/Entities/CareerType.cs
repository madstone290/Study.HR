using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 경력 타입
    /// </summary>
    public class CareerType : Entity
    {
        protected CareerType() { }
        public CareerType(string code, string name)
        {
            ChangeCode(code);
            ChangeName(name);
        }


        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; private set; } = string.Empty;

        /// <summary>
        /// 코드 변경
        /// </summary>
        /// <param name="code"></param>
        public void ChangeCode(string code)
        {
            ThrowIf(string.IsNullOrWhiteSpace(code), "Code is empty");
            Code = code;
        }

        /// <summary>
        /// 이름 변경
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(string name)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            Name = name;
        }
    }
}
