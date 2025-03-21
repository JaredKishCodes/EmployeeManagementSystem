using EmployeeManagements.Models;

namespace EmployeeManagement.API.Data.Repository
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetDepartments();
        public Task<Department> GetDepartmentById(int departmentId);
    }
}
