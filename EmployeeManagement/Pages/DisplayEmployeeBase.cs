using EmployeeModel;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeManagement.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {
        [Parameter]
        public Employee employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmplyeeSelection { get; set; }

        public bool IsSelected; 
        
        public async Task TextBoxChanged( ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnEmplyeeSelection.InvokeAsync(IsSelected);
        }

    }
}
