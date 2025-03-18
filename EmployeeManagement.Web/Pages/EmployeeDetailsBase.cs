using EmployeeManagement.Web.Services;
using EmployeeManagements.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected bool FooterVisible { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
          Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
        }

        protected async Task Button_Click()
        {
            Console.WriteLine("Button Clicked!"); // Debugging Log


            FooterVisible = !FooterVisible;
            ButtonText = FooterVisible ? "Hide Footer" : "Show Footer";
                
            
            
           
            await InvokeAsync(StateHasChanged); // Ensures UI update
        }


    }
}
