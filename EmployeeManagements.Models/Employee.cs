﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagements.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [MinLength (2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
