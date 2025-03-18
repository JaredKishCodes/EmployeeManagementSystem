using EmployeeManagement.Web.Services;
using EmployeeManagements.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
          Employees = ( await EmployeeService.GetEmployees());
           
        }
    }
}
