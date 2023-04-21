using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 부서
    /// </summary>
    public class Department : Entity
    {
        protected Department() { }

        public static async Task<Department> CreateAsync(string code, string name, IDepartmentService service)
        {
            Department department = new Department();
            await department.ChangeCodeAsync(code, service);
            await department.ChangeNameAsync(name, service);
            return department;
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
        /// 상위 부서
        /// </summary>
        public int? UpperDepartmentId { get; private set; }

        /// <summary>
        /// 상위 부서
        /// </summary>
        public Department? UpperDepartment { get; private set; }

        /// <summary>
        /// 코드 변경
        /// </summary>
        /// <param name="code"></param>
        public async Task ChangeCodeAsync(string code, IDepartmentService service)
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
        public async Task ChangeNameAsync(string name, IDepartmentService service)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            if (Name == name)
                return;
            ThrowIf(await service.NameExistAsync(name), "Name exist!");
            Name = name;
        }

        public void ChangeUpperDepartment(Department? department)
        {
            ThrowIf(department != null && department.Id == Id, "Upper department id is the same as me!");
                
            UpperDepartment = department;
        }

    }
}
