using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee() { }
        public Employee(string name, DateTime enteredDate)
        {
            Name = name;
        }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 사원코드
        /// </summary>
        public string Code { get; private set; } = string.Empty;

        /// <summary>
        /// 영문이름
        /// </summary>
        public string? EnglishName { get; private set; }

        /// <summary>
        /// 주민등록번호
        /// </summary>
        public string? ResidentNumber { get; private set; }

        /// <summary>
        /// 세대주 여부
        /// </summary>
        public bool IsHouseOwner { get; private set; }

        /// <summary>
        /// 입사일
        /// </summary>
        public DateTime? HireDate { get; private set; }

        /// <summary>
        /// 퇴사일
        /// </summary>
        public DateTime? RetireDate { get; private set; }

        /// <summary>
        /// 퇴사사유
        /// </summary>
        public string? RetireReason { get; private set; }

        /// <summary>
        /// 이메일
        /// </summary>
        public string? Email { get; private set; }

        /// <summary>
        /// 집전화번호
        /// </summary>
        public string? PhoneNumber { get; private set; }

        /// <summary>
        /// 휴대폰번호
        /// </summary>
        public string? MobileNumber { get; private set; }

        /// <summary>
        /// 집주소
        /// </summary>
        public string? Address { get; private set; }

        /// <summary>
        /// 우편번호
        /// </summary>
        public string? ZipCode { get; private set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string? Password { get; private set; }

        /// <summary>
        /// 메모
        /// </summary>
        public string? Memo { get; private set; }

        /// <summary>
        /// 이미지 경로
        /// </summary>
        public string? ImagePath { get; private set; }

        /// <summary>
        /// 급여정보
        /// </summary>
        public PayProfile? PayProfile { get; private set; }

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobPositionId { get; private set; }

        /// <summary>
        /// 직위
        /// </summary>
        public JobPosition? JobPosition { get; private set; }

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobRoleId { get; private set; }

        /// <summary>
        /// 직책
        /// </summary>
        public JobRole? JobRole { get; private set; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public int? CareerTypeId { get; private set; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public CareerType? CareerType { get; private set; }


        /// <summary>
        /// 고용타입
        /// </summary>
        public int? EmploymentTypeId { get; private set; }

        /// <summary>
        /// 고용타입
        /// </summary>
        public EmploymentType? EmploymentType { get; private set; }


    }
}
