namespace Study.HR.Controllers.Parameters
{
    public class EmployeeParam
    {
        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 영문이름
        /// </summary>
        public string? EnglishName { get; set; }

        /// <summary>
        /// 주민등록번호
        /// </summary>
        public string? ResidentNumber { get; set; }

        /// <summary>
        /// 세대주 여부
        /// </summary>
        public bool IsHouseOwner { get; set; }

        /// <summary>
        /// 입사일
        /// </summary>
        public DateTime? HireDate { get; set; }

        /// <summary>
        /// 퇴사일
        /// </summary>
        public DateTime? RetireDate { get; set; }

        /// <summary>
        /// 퇴사사유
        /// </summary>
        public string? RetireReason { get; set; }

        /// <summary>
        /// 이메일
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 집전화번호
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// 휴대폰번호
        /// </summary>
        public string? MobileNumber { get; set; }

        /// <summary>
        /// 집주소
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// 우편번호
        /// </summary>
        public string? ZipCode { get; set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// 메모
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 이미지 경로
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobPositionId { get; set; }

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobRoleId { get; set; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public int? CareerTypeId { get; set; }

        /// <summary>
        /// 고용타입
        /// </summary>
        public int? EmploymentTypeId { get; set; }

    }
}
