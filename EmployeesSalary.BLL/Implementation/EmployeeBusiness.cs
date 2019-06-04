using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeesSalary.Common;
using EmployeesSalary.Common.Utils;
using EmployeesSalary.DAL;

namespace EmployeesSalary.BLL
{
    public class EmployeeBusiness : IEmployeeBusiness
    {

        IEmployeeData _EmployeesData;

        public EmployeeBusiness()
        {
            _EmployeesData = new EmployeeData();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            try
            {
                var result = await _EmployeesData.GetAll();
                return result;
            }
            catch (Exception)
            {                              
                throw;
            }
        }

        public async Task<EmployeeDto> GetById(int employeeId)
        {
            try
            {
                var result = await _EmployeesData.GetById(employeeId);                
                ContractType contract = (ContractType)Enum.Parse(typeof(ContractType), result.ContractTypeName, true);
                return EmployeeFactory.CreateSalaryByContractName(contract, result);
            }
            catch (Exception)
            {
                return new EmployeeDto();             
            }
        }
    }
}
