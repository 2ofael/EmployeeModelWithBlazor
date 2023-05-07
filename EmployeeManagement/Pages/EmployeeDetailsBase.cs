using EmployeeManagement.Services;
using EmployeeModel;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Pages
{
    public class EmployeeDetailsBase:ComponentBase
    {
        [Inject]
        public IEmployeeServices employeeServices { get; set; }

        [Parameter]
        public string Id { get; set; }
        public Employee employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
            employee = await employeeServices.GetEmployee(int.Parse(Id));
            
        }

    }
}
