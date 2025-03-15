    using EmployeeManagement.API.Data.Repository;
    using EmployeeManagements.Models;
    using Microsoft.AspNetCore.Mvc;

    namespace EmployeeManagement.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet("{search}")]

        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender) 
        {
            try
            {
                var result = await _employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");

            }

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Enter valid ID");
                }

                var employee = await _employeeRepository.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound("Employee Not Found");
                }

                return Ok(employee);
            }
            catch (Exception)
            {


                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]

        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Failed to create employee.");
                }

                var emp = _employeeRepository.GetEmployeeByEmail(employee.Email);

                if (emp != null)
                {
                    ModelState.AddModelError("email", "Employee email is already in use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await _employeeRepository.CreateEmployee(employee);

                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeId }, createdEmployee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating data from the database");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var employeeToUpdate = await _employeeRepository.GetEmployeeById(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with the id : {id} not found");
                }

                await _employeeRepository.UpdateEmployee(employee);
                return NoContent();


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error updating data from the database");
            }

        }

             [HttpDelete("{id:int}")]

             public async Task<ActionResult> DeleteEmployee(int id) 
            {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Enter valid ID");
                }

                var employeeToDelete = await _employeeRepository.GetEmployeeById(id);

                if (employeeToDelete == null) 
                {
                    return NotFound($"Employee with the id : {id} not found");
                }

                await _employeeRepository.DeleteEmployee(employeeToDelete);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error deleting data from the database");
            }
            }


        }
    }
