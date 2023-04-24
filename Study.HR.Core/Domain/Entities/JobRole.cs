using Study.HR.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 직무/직책
    /// </summary>
    public class JobRole : Entity
    {
        protected JobRole() { }

        public static async Task<JobRole> CreateAsync(string code, string name, IJobRoleService service)
        {
            JobRole jobRole = new JobRole();
            await jobRole.ChangeCodeAsync(code, service);
            await jobRole.ChangeNameAsync(name, service);
            return jobRole;
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
        public async Task ChangeCodeAsync(string code, IJobRoleService service)
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
        public async Task ChangeNameAsync(string name, IJobRoleService service)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            if (Name == name)
                return;
            ThrowIf(await service.NameExistAsync(name), "Name exist!");
            Name = name;
        }
    }
}
