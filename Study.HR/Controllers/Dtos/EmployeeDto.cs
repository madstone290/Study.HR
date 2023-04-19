namespace Study.HR.Controllers.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime EnteredDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SalaryType { get; set; }
        public decimal BaseSalary { get; set; }
        public string? SalaryCurrency { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? LoginId { get; set; }

        public string? LoginPassword { get; set; }
        public string? Desc { get; set; }
        public int Rate { get; set; }
    }
}
