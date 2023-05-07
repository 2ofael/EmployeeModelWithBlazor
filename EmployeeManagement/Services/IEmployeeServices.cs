using EmployeeModel;

namespace EmployeeManagement.Services
{
    public interface IEmployeeServices
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int Id);
    }
}
