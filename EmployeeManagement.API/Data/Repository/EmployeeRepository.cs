using EmployeeManagements.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace EmployeeManagement.API.Data.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            employee.EmployeeId = 0;
            var result =  await _appDbContext.Employees.AddAsync(employee);
           await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
             _appDbContext.Remove(employee);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
          return  await _appDbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);

        }

        public async Task<List<Employee>> GetEmployees()
        {
           return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var results = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (results != null) 
            { 
                results.EmployeeId = employee.EmployeeId;
                results.FirstName = employee.FirstName; 
                results.LastName = employee.LastName;   
                results.Email = employee.Email;
                results.DateOfBrith = employee.DateOfBrith;
                results.Gender = employee.Gender;
                results.DepartmentId = employee.DepartmentId;
                results.PhotoPath = employee.PhotoPath;
                
                await _appDbContext.SaveChangesAsync();

                return results;
            }

            return null;
        }

        public async Task<List<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
