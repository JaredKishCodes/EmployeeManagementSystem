using EmployeeManagements.Models;

namespace EmployeeManagement.API.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> Search(string name, Gender? gender);
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(Employee employee);
    }
}
