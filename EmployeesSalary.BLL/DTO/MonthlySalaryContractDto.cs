using System;
using EmployeesSalary.Common;

namespace EmployeesSalary.BLL
{
    public class MonthlySalaryContractDto : EmployeeDto
    {
        /*public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }        
        public string RoleName { get; set; }                
        public string MonthlySalary { get; set; }
        public int CalculatedAnualSalary { get; set; }*/

        public MonthlySalaryContractDto(EmployeeDto employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleName = employee.RoleName;
            MonthlySalary = employee.MonthlySalary;
            CalculatedAnualSalary = ((Convert.ToInt32(employee.MonthlySalary) * 12));

        }
    }
}
