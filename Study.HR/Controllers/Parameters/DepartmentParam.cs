namespace Study.HR.Controllers.Parameters
{
    public class DepartmentParam
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? UpperDepartmentId { get; set; }
    }
}
