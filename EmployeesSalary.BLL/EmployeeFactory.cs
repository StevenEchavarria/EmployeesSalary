using EmployeesSalary.Common;
using EmployeesSalary.Common.Utils;

namespace EmployeesSalary.BLL
{
    public static class EmployeeFactory
    {
        public static EmployeeDto CreateSalaryByContractName(ContractType contractType, EmployeeDto employee)
        {
            EmployeeDto salary = null;

            switch (contractType)
            {
                case ContractType.HourlySalaryEmployee:
                    salary = new HourlySalaryContractDto(employee);
                    break;
                case ContractType.MonthlySalaryEmployee:
                    salary = new MonthlySalaryContractDto(employee);
                    break;
            }

            return salary;
        }
    }
}
