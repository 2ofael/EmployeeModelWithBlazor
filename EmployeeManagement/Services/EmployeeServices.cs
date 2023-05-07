using EmployeeModel;
using Microsoft.VisualBasic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace EmployeeManagement.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient httpClient;

        public EmployeeServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var emp = new  List<Employee>();

            var result = await httpClient.GetFromJsonAsync<List<Employee>>("api/Employees");

            if (result != null)
            {
                emp = result.ToList();
            }
            return emp;
        }

       public async  Task<Employee> GetEmployee(int Id)
        {

            var result = await httpClient.GetFromJsonAsync<Employee>($"api/Employees/{Id}");
            return result;
        }

        
    }
}
