using Study.HR.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 고용 타입
    /// </summary>
    public class EmploymentType : Entity
    {
        protected EmploymentType() { }

        public static async Task<EmploymentType> CreateAsync(string code, string name, IEmploymentTypeService service)
        {
            EmploymentType employmentType = new EmploymentType();
            await employmentType.ChangeCodeAsync(code, service);
            await employmentType.ChangeNameAsync(name, service);
            return employmentType;
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
        public async Task ChangeCodeAsync(string code, IEmploymentTypeService service)
        {
            ThrowIf(string.IsNullOrWhiteSpace(code), "Code is empty");
            if (Code == code)
                return;
            ThrowIf(await service.CodeExistAsync(code), "Code exist!");
            Code = code;
        }

        /// <summary>
        /// 이름 변경
        /// </summary>
        /// <param name="name"></param>
        public async Task ChangeNameAsync(string name, IEmploymentTypeService service)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            if (Name == name)
                return;
            ThrowIf(await service.NameExistAsync(name), "Name exist!");
            Name = name;
        }
    }
}
