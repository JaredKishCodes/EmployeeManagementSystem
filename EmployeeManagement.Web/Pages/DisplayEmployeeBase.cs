﻿using EmployeeManagements.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e) 
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);

        }
    }
}
