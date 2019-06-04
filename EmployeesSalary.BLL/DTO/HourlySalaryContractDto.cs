using System;
using EmployeesSalary.Common;

namespace EmployeesSalary.BLL
{
    public class HourlySalaryContractDto : EmployeeDto
    {
        /*public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }        
        public string RoleName { get; set; }                
        public string HourlySalary { get; set; }
        public int CalculatedAnualSalary { get; set; }*/

        public HourlySalaryContractDto(EmployeeDto employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleName = employee.RoleName;
            HourlySalary = employee.HourlySalary;
            CalculatedAnualSalary = (120 * (Convert.ToInt32(employee.HourlySalary) * 12));

        }
    }
}
