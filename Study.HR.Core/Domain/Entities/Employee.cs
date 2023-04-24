using Study.HR.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Entities
{
    public class Employee : Entity, IHasCode, IHasName
    {
        protected Employee() { }

        public static async Task<Employee> CreateAsync(string code, string name, IEmployeeService service)
        {
            Employee employee = new Employee();
            await employee.ChangeCodeAsync(code, service);
            employee.ChangeName(name);
            return employee;
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



        /// <summary>
        /// 코드 변경
        /// </summary>
        /// <param name="code"></param>
        public async Task ChangeCodeAsync(string code, IEmployeeService service)
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
        public void ChangeName(string name)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            if (Name == name)
                return;
            Name = name;
        }

        public void ChangeJobPosition(JobPosition? jobPosition)
        {
            JobPosition = jobPosition;
        }

        public void ChangeJobRole(JobRole? jobRole)
        {
            JobRole = jobRole;
        }

        public void ChangeEmploymentType(EmploymentType? employmentType)
        {
            EmploymentType = employmentType;
        }

        public void ChangeCareerType(CareerType? careerType)
        {
            CareerType = careerType;
        }

        public void Retire(DateTime? retireDate, string? retireReason)
        {
            RetireDate = retireDate;
            RetireReason = retireReason;
        }

        public void ChangeEnglishName(string? englishName)
        {
            EnglishName = englishName;
        }

        public void ChangeHouseOwner(bool isHouseOwner)
        {
            IsHouseOwner = isHouseOwner;
        }

        public void ChangeHireDate(DateTime? hireDate)
        {
            HireDate = hireDate;
        }

        public void ChangeOthers(string? memo, string? imagePath)
        {
            Memo = memo;
            ImagePath = imagePath;
        }

        public void ChangeResidentNumber(string? residentNumber)
        {
            ResidentNumber = residentNumber;
        }

        public void ChangePassword(string? password, IHashService service)
        {
            if (string.IsNullOrWhiteSpace(password))
                Password = null;
            else
                Password = service.Hash(password);
        }

        public void ChangeContact(string? email, string? phoneNumber, string? mobileNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
        }

        public void ChangeAddressInfo(string? address, string? zipCode)
        {
            Address = address;
            ZipCode = zipCode;
        }
    }
}
