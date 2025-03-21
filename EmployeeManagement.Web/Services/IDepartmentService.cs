using EmployeeManagements.Models;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetDepartmentsAsync();

        public Task<Department> GetDepartmentByIdAsync(int id);
        

    }
}
