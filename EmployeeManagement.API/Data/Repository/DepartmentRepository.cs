using EmployeeManagements.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await _appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<List<Department>> GetDepartments()
        {
            try
            {
                return await _appDbContext.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving data: {ex.Message}", ex);
            }
        }

    }
}
