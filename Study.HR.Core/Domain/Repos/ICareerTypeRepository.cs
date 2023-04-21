using Study.HR.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Repos
{
    public interface ICareerTypeRepository : IRepository<CareerType>
    {
        /// <summary>
        /// 코드 중복확인
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<bool> ExistCodeAsync(string code);

        /// <summary>
        /// 이름 중복확인
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> ExistNameAsync(string name);
    }
}
