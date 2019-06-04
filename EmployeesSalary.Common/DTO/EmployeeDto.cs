using EmployeesSalary.Common.Utils;
using System;

namespace EmployeesSalary.Common
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string HourlySalary { get; set; }
        public string MonthlySalary { get; set; }
        public long CalculatedAnualSalary { get; set; }

        public EmployeeDto()
        {

        }

        public EmployeeDto(int id, string name, string contractType, string roleId, string roleName, string roleDescription,
            string hourlySalary, string monthlySalary)
        {
            Id = id;
            Name = name;
            ContractTypeName = contractType;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
            HourlySalary = hourlySalary.Substring(0, hourlySalary.Length - 2);
            MonthlySalary = monthlySalary.Substring(0, monthlySalary.Length - 2);                      
            if (contractType == ContractType.HourlySalaryEmployee.ToString())
            {
                CalculatedAnualSalary = (120 * (Convert.ToInt32(hourlySalary.Substring(0, monthlySalary.Length - 2)) * 12));
            }
            else {
                CalculatedAnualSalary = ((Convert.ToInt32(monthlySalary.Substring(0, monthlySalary.Length - 2)) * 12));
            }            
        }

    }
}
