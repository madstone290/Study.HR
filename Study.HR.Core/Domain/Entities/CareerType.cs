using Study.HR.Core.Domain.Services;

namespace Study.HR.Core.Domain.Entities
{
    /// <summary>
    /// 경력 타입
    /// </summary>
    public class CareerType : Entity
    {
        protected CareerType() { }

        public static async Task<CareerType> CreateAsync(string code, string name, ICareerTypeService service)
        {
            CareerType careerType = new CareerType();
            await careerType.ChangeCodeAsync(code, service);
            await careerType.ChangeNameAsync(name, service);
            return careerType;
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
        public async Task ChangeCodeAsync(string code, ICareerTypeService service)
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
        public async Task ChangeNameAsync(string name, ICareerTypeService service)
        {
            ThrowIf(string.IsNullOrWhiteSpace(name), "Name is empty");
            if (Name == name)
                return;
            ThrowIf(await service.NameExistAsync(name), "Name exist!");
            Name = name;
        }
    }
}
