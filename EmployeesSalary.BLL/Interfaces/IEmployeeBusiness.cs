using EmployeesSalary.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesSalary.BLL
{
    public interface IEmployeeBusiness
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int employeeId);        
    }
}
