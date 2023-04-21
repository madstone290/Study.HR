using Study.HR.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Dto
{
    public record DepartmentDto
    {
        public int Id { get; init; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; init; } = string.Empty;

        /// <summary>
        /// 상위 부서
        /// </summary>
        public int? UpperDepartmentId { get; init; }

    }
}
