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
            EnteredDate = enteredDate;
        }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime EnteredDate { get; set; }

        public string? SalaryType { get; set; }
        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? LoginId { get; set; }

        public string? LoginPassword { get; set; }

        public string? PhoneNumber { get; set; }
        public decimal BaseSalary { get; set; }
        public string? SalaryCurrency { get; set; }

        public EmployeeDetail Detail { get; set; }

        
        




    }
}
