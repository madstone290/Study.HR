using Study.HR.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Dto
{
    public record EmployeeDto()
    {
        public int Id { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; init; } = string.Empty;

        /// <summary>
        /// 영문이름
        /// </summary>
        public string? EnglishName { get; init; }

        /// <summary>
        /// 주민등록번호
        /// </summary>
        public string? ResidentNumber { get; init; }

        /// <summary>
        /// 세대주 여부
        /// </summary>
        public bool IsHouseOwner { get; init; }

        /// <summary>
        /// 입사일
        /// </summary>
        public DateTime? HireDate { get; init; }

        /// <summary>
        /// 퇴사일
        /// </summary>
        public DateTime? RetireDate { get; init; }

        /// <summary>
        /// 퇴사사유
        /// </summary>
        public string? RetireReason { get; init; }

        /// <summary>
        /// 이메일
        /// </summary>
        public string? Email { get; init; }

        /// <summary>
        /// 집전화번호
        /// </summary>
        public string? PhoneNumber { get; init; }

        /// <summary>
        /// 휴대폰번호
        /// </summary>
        public string? MobileNumber { get; init; }

        /// <summary>
        /// 집주소
        /// </summary>
        public string? Address { get; init; }

        /// <summary>
        /// 우편번호
        /// </summary>
        public string? ZipCode { get; init; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string? Password { get; init; }

        /// <summary>
        /// 메모
        /// </summary>
        public string? Memo { get; init; }

        /// <summary>
        /// 이미지 경로
        /// </summary>
        public string? ImagePath { get; init; }

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobPositionId { get; init; }

        public string? JobPositionName { get; init; }

        public string? JobPositionCode { get; init; }

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobRoleId { get; init; }

        public string? JobRoleName { get; init; }

        public string? JobRoleCode { get; init; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public int? CareerTypeId { get; init; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public string? CareerTypeName { get; init; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public string? CareerTypeCode { get; init; }

        /// <summary>
        /// 고용타입
        /// </summary>
        public int? EmploymentTypeId { get; init; }

        /// <summary>
        /// 고용타입
        /// </summary>
        public string? EmploymentTypeName { get; init; }

        /// <summary>
        /// 고용타입
        /// </summary>
        public string? EmploymentTypeCode { get; init; }
    }
}
