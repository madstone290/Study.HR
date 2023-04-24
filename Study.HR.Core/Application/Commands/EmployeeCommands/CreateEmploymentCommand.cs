using Study.HR.Core.Application.Base;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;
using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Application.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : ICommand<int>
    {
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

        /// <summary>
        /// 직위
        /// </summary>
        public int? JobRoleId { get; init; }

        /// <summary>
        /// 경력타입
        /// </summary>
        public int? CareerTypeId { get; init; }

        /// <summary>
        /// 고용타입
        /// </summary>
        public int? EmploymentTypeId { get; init; }

    }

    public class CreateEmploymentCommandHandler : ICommandHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeService _service;
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IJobRoleRepository _jobRoleRepository;
        private readonly IEmploymentTypeRepository _employmentTypeRepository;
        private readonly ICareerTypeRepository _careerTypeRepository;
        private readonly IHashService _hashService;

        public CreateEmploymentCommandHandler(IEmployeeRepository repository,
                                              IEmployeeService service,
                                              IJobPositionRepository jobPositionRepository,
                                              IJobRoleRepository jobRoleRepository,
                                              IEmploymentTypeRepository employmentTypeRepository,
                                              ICareerTypeRepository careerTypeRepository,
                                              IHashService hashService)
        {
            _repository = repository;
            _service = service;
            _jobPositionRepository = jobPositionRepository;
            _jobRoleRepository = jobRoleRepository;
            _employmentTypeRepository = employmentTypeRepository;
            _careerTypeRepository = careerTypeRepository;
            _hashService = hashService;
        }

        public async Task<int> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            Employee employee = await Employee.CreateAsync(command.Code, command.Name, _service);

            JobPosition? jobPosition = await _jobPositionRepository.FindOrThrowAsync(command.JobPositionId);
            employee.ChangeJobPosition(jobPosition);

            JobRole? jobRole = await _jobRoleRepository.FindOrThrowAsync(command.JobRoleId);
            employee.ChangeJobRole(jobRole);

            EmploymentType? employmentType = await _employmentTypeRepository.FindOrThrowAsync(command.EmploymentTypeId);
            employee.ChangeEmploymentType(employmentType);

            CareerType? careerType = await _careerTypeRepository.FindOrThrowAsync(command.CareerTypeId);
            employee.ChangeCareerType(careerType);

            employee.ChangeEnglishName(command.EnglishName);
            employee.ChangeHouseOwner(command.IsHouseOwner);
            employee.ChangeHireDate(command.HireDate);
            employee.ChangeOthers(command.Memo, command.ImagePath);
            employee.ChangeResidentNumber(employee.ResidentNumber);
            employee.ChangePassword(command.Password, _hashService);
            employee.ChangeContact(command.Email, command.PhoneNumber, command.MobileNumber);
            employee.ChangeAddressInfo(command.Address, command.ZipCode);
            employee.Retire(command.RetireDate, command.RetireReason);


            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
            return employee.Id;
        }
    }
}
