namespace Study.HR.Controllers.Dtos
{
    public class EmployeeSalaryDto
    {
        public int EmployeeId { get; set; }
        public double BaseSalary { get; set; }
        public double BonusRate { get; set; } = 1.0;
        public DateTime ValidAfter { get; set; }
        public DateTime ValidBefore { get; set; }
    }
}
