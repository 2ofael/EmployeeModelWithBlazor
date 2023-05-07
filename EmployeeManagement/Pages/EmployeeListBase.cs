using EmployeeManagement.Services;
using EmployeeModel;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;


namespace EmployeeManagement.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices employeeServices { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public bool Footer { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            //   LoadEmployees(); //
            //
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7109/") };

            var result = await employeeServices.GetEmployees(); //await client.GetFromJsonAsync<List<Employee>>("api/Employees");
            Employees = result.ToList();
        }
        protected int SelectedEmployeesCount { get; set; } = 0;
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            { SelectedEmployeesCount--; }

        }
    }
        
}
