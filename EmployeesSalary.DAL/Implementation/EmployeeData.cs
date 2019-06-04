using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Net.Http.Headers;
using EmployeesSalary.Common;

namespace EmployeesSalary.DAL
{
    public class EmployeeData : IEmployeeData
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            HttpClient client = new HttpClient();
            string path = ClientConfiguration(client);

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                List<EmployeeDto> _listReturn = new List<EmployeeDto>();
                var list = JsonConvert.DeserializeObject<List<EmployeeDto>>(response.Content.ReadAsStringAsync().Result);
                foreach (var item in list)
                {
                    var employee = new EmployeeDto(item.Id, item.Name, item.ContractTypeName, item.RoleId, item.RoleName, item.RoleDescription, item.HourlySalary, item.MonthlySalary);
                    _listReturn.Add(employee);
                }

                return _listReturn;

            }
            else {
                return new List<EmployeeDto>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> GetById(int employeeId)
        {
            HttpClient client = new HttpClient();
            string path = ClientConfiguration(client);

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var listResult = JsonConvert.DeserializeObject<List<EmployeeDto>>(response.Content.ReadAsStringAsync().Result);
                var result = listResult.Where(s => s.Id == employeeId).FirstOrDefault();                
                if (result != null && result.Id != 0)
                {                    
                    return new EmployeeDto(result.Id, result.Name, result.ContractTypeName, result.RoleId, result.RoleName, result.RoleDescription, result.HourlySalary, result.MonthlySalary);
                }
                else {                    
                    return new EmployeeDto();
                }                
            }
            else
            {
                return new EmployeeDto();
            }
        }

        private static string ClientConfiguration(HttpClient client)
        {
            string path = "http://masglobaltestapi.azurewebsites.net/api/Employees";

            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return path;
        }
    }
}
