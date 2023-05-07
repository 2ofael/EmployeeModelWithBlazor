using EmployeeManagement.web.Models;
using EmployeeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }

        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int Id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(Id);
                if (result == null)
                    return NotFound();

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }

        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var emp = employeeRepository.GetEmployeeByEmail(employee.Email);
                if (emp != null)
                {
                    ModelState.AddModelError("email", "employee email is laready used");
                    return BadRequest(ModelState);
                }
                var createdEmployee = await employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);


            }
            catch (Exception)
            {

            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id ,  Employee emp)
        {
            try
            {
                if(id != emp.EmployeeId)
                {
                    return BadRequest("Employee Id mismatch");
                }
                var employeeToUpdate = await employeeRepository.GetEmployee(id);
                if (employeeToUpdate==null) {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await employeeRepository.UpdateEmployee(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Updating error{ex}");

            }

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
              var employeeToDelete  = await employeeRepository.GetEmployee(id);
            if(employeeToDelete==null) {
                    return NotFound($"No employee with this Id = {id}");
                        }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Deleting error{ex}");

            }

        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender ? gender)
        {
            try
            {
             var result =    await employeeRepository.Search(name,gender);
            if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorret");


            }
        }

    }
}