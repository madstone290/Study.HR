using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Application.Dto;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Domain.Entities;
using Study.HR.Core.Domain.Repos;

namespace Study.HR.Core.Infrastructure.Data.Repos
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository, IEmployeeReadRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> ExistCodeAsync(string code)
        {
            return Set.ExistCodeAsync<Employee, int>(code);
        }

        public Task<List<EmployeeDto>> GetListAsync()
        {
            return Set.SelectEmployeeDto().OrderBy(x => x.Id).ToListAsync();
        }
    }

    public static class EmployeeRepositoryExtensions
    {
        public static IQueryable<EmployeeDto> SelectEmployeeDto(this IQueryable<Employee> query)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return query.Select(emp => new EmployeeDto()
            {
                Id = emp.Id,
                Code = emp.Code,
                Name = emp.Name,
                ResidentNumber = emp.ResidentNumber,
                HireDate = emp.HireDate,
                RetireDate = emp.RetireDate,
                RetireReason = emp.RetireReason,
                EnglishName = emp.EnglishName,
                IsHouseOwner = emp.IsHouseOwner,
                Memo = emp.Memo,
                ImagePath = emp.ImagePath,
                Password = emp.Password,
                Email = emp.Email,
                MobileNumber = emp.MobileNumber,
                PhoneNumber = emp.PhoneNumber,
                Address = emp.Address,
                ZipCode = emp.ZipCode,
                CareerTypeId = emp.CareerTypeId,
                CareerTypeCode = emp.CareerType.Code,
                CareerTypeName = emp.CareerType.Name,
                EmploymentTypeId = emp.EmploymentTypeId,
                EmploymentTypeCode = emp.EmploymentType.Code,
                EmploymentTypeName = emp.EmploymentType.Name,
                JobRoleId = emp.JobRoleId,
                JobRoleCode = emp.JobRole.Code,
                JobRoleName = emp.JobRole.Name,
                JobPositionId = emp.JobPositionId,
                JobPositionCode = emp.JobPosition.Code,
                JobPositionName = emp.JobPosition.Name,

            });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
