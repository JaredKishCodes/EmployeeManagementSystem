using EmployeeManagements.Models;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"api/departments/{id}");
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Department[]>($"api/departments");
        }
    }
}
