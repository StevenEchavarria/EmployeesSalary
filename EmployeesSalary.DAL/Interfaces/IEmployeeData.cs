using EmployeesSalary.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesSalary.DAL
{
    public interface IEmployeeData
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int employeeId);
    }
}
