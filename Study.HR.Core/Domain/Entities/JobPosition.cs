using Study.HR.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 직위
    /// </summary>
    public class JobPosition : Entity
    {
        protected JobPosition() { }

        public static async Task<JobPosition> CreateAsync(string code, string name, IJobPositionService service)
        {
            JobPosition jobPosition = new JobPosition();
            await jobPosition.ChangeCodeAsync(code, service);
            await jobPosition.ChangeNameAsync(name, service);
            return jobPosition;
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
        public async Task ChangeCodeAsync(string code, IJobPositionService service)
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
        public async Task ChangeNameAsync(string name, IJobPositionService service)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            if (Name == name)
                return;
            ThrowIf(await service.NameExistAsync(name), "Name exist!");
            Name = name;
        }
    }
}
