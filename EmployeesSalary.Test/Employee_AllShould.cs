using EmployeesSalary.BLL;
using Xunit;

namespace EmployeesSalary.Test
{
    public class Employee_AllShould
    {

        public IEmployeeBusiness _EmployeeBusiness;

        public Employee_AllShould()
        {
            _EmployeeBusiness = new EmployeeBusiness();
        }

        [Fact]
        public void ReturnTrueGivenHourlySalaryContract()
        {
            /*EmployeeDto _employee = new EmployeeDto
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = "1",
                RoleName = "Administrator",
                RoleDescription = null,
                HourlySalary = "60000",
                MonthlySalary = "80000"
            };*/

            var result = _EmployeeBusiness.GetById(1);
            Assert.True(result.Result.CalculatedAnualSalary == 86400000, "Employee calculated salary is right!");
        }

        [Fact]
        public void ReturnTrueGivenMonthlySalaryContract()
        {
            /*EmployeeDto _employee = new EmployeeDto
            {
                Id = 2,
                Name = "Sebastian",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = "2",
                RoleName = "Contractor",
                RoleDescription = null,
                HourlySalary = "60000",
                MonthlySalary = "80000"
            };*/

            var result = _EmployeeBusiness.GetById(2);
            Assert.True(result.Result.CalculatedAnualSalary == 960000, "Employee calculated salary is right!");
        }
    }
}
