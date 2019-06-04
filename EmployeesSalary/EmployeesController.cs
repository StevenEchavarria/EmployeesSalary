using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeesSalary.BLL;
using EmployeesSalary.Common;
using Microsoft.AspNetCore.Mvc;


namespace EmployeesSalary
{
  [Route("api/[controller]")]
  public class EmployeesController : Controller
  {

    public IEmployeeBusiness _EmployeeBusiness;

    public EmployeesController()
    {
      _EmployeeBusiness = new EmployeeBusiness();
    }
    
    [HttpGet("getAllEmployees")]
    public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
    {
      var result = await _EmployeeBusiness.GetAll();
      return result;
    }

    [HttpGet("getEmployeeById/{employeeId}")]
    public async Task<EmployeeDto> getEmployeeById(int employeeId)
    {
      var result = await _EmployeeBusiness.GetById(employeeId);

      return result;
    }
  }
}
