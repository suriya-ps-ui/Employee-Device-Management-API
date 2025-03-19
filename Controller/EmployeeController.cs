using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Model;

namespace Controllers{
    [ApiController]
    [Route("/[controller]")]
    public class EmployeeController:ControllerBase{
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService){
            this.employeeService=employeeService;
        }

        [HttpGet("Employees")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> GetAllEmployees(){
            var employees=await employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("Employees/{empId}")]
        [Authorize]
        public async Task<IActionResult> GetEmployee(string empId){
            var employee=await employeeService.GetEmployeeByIDAsync(empId);
            if(employee==null){
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("Employees")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequest employeeRequest){
            var employee=new Employee{
                empId=employeeRequest.empId,
                empName=employeeRequest.empName,
                department=employeeRequest.department
            };
            var newEmployee=await employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee),new{empId=newEmployee.empId},newEmployee);
        }

        [HttpPut("Employees/{empId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateEmployee(string empId,[FromBody] EmployeeRequest employeeRequest){
            var employee=new Employee{
                empId=employeeRequest.empId,
                empName=employeeRequest.empName,
                department=employeeRequest.department
            };
            await employeeService.UpdateEmployeeAsync(empId,employee);
            return NoContent();
        }
        [HttpDelete("Employees/{empId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteEmployee(string empId){
            await employeeService.DeleteEmployeeAsync(empId);
            return NoContent();
        }

    }
}