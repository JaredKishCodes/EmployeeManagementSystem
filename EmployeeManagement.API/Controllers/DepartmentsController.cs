using EmployeeManagement.API.Data.Repository;
using EmployeeManagements.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]

        public async Task<IActionResult> GetDepartmentsAsync() {
            try
            {
                return Ok(await _departmentRepository.GetDepartments());
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentByIdAsync(int departmentId)
        {
            try
            {
                if (departmentId <= 0) 
                {
                    BadRequest("Enter valid ID");
                }

                var result = await _departmentRepository.GetDepartmentById(departmentId);

                if(result == null) 
                {
                    return NotFound($"The Id : {departmentId} can not be found.");
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
    }
}
