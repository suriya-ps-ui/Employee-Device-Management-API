using Microsoft.AspNetCore.Mvc;
using Services;
using Model;
using Microsoft.AspNetCore.Authorization;

namespace Controllers{
    [ApiController]
    [Route("/[controller]")]
    public class AssetManagementController:ControllerBase{
        IEmployeeService employeeService;
        IDeviceService deviceService;
        IAuthService authService;
        public AssetManagementController(IEmployeeService employeeService,IDeviceService deviceService,IAuthService authService){
            this.employeeService=employeeService;
            this.deviceService=deviceService;
            this.authService=authService;
        }
        // Authentication
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest){
            try{
                var token=await authService.LoginAsync(loginRequest.username,loginRequest.password);
                return Ok(new{Token=token});
            }
            catch (Exception ex){
                return Unauthorized(ex.Message);
            }
        }
        [HttpPost("Register")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest){
            try{
                await authService.RegisterUserAsync(registerRequest.username,registerRequest.Password,registerRequest.role,registerRequest.empId);
                return Ok("User registered successfully");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
        // Employees
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
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee){
            var newEmployee=await employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee),new{empId=newEmployee.empId},newEmployee);
        }

        [HttpPut("Employees/{empId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateEmployee(string empId,[FromBody] Employee employee){
            await employeeService.UpdateEmployeeAsync(empId,employee);
            return NoContent();
        }
        [HttpDelete("Employees/{empId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteEmployee(string empId){
            await employeeService.DeleteEmployeeAsync(empId);
            return NoContent();
        }

        // Laptops
        [HttpGet("Employees/{empId}/Laptops")]
        [Authorize]
        public async Task<IActionResult> GetLaptops(string empId){
            var laptops=await deviceService.GetLaptopsByEmployeeAsync(empId);
            return Ok(laptops);
        }
        [HttpPost("Employees/{empId}/Laptops")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateLaptop(string empId,[FromBody] Laptop laptop){
            var newLaptop=await deviceService.CreateLaptopAsync(laptop);
            return CreatedAtAction(nameof(GetLaptops),new{empId=newLaptop.empId,lapHostName=newLaptop.lapHostName},newLaptop);
        }
        [HttpPut("Employees/{empId}/Laptops/{lapHostName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLaptop(string empId,string lapHostName,[FromBody] Laptop laptop){
            await deviceService.UpdateLaptopAsync(empId,lapHostName,laptop);
            return NoContent();
        }
        [HttpDelete("Employees/{empId}/Laptops/{lapHostName}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteLaptop(string empId, string lapHostName){
            await deviceService.DeleteLaptopAsync(empId, lapHostName);
            return NoContent();
        }

        // Keyboards
        [HttpGet("Employees/{empId}/Keyboards")]
        [Authorize]
        public async Task<IActionResult> GetKeyboards(string empId){
            var keyboards=await deviceService.GetKeyboardsByEmployeeAsync(empId);
            return Ok(keyboards);
        }
        [HttpPost("Employees/{empId}/Keyboards")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateKeyboard(string empId,[FromBody] Keyboard keyboard){
            keyboard.empId=empId;
            var newKeyboard=await deviceService.CreateKeyboardAsync(keyboard);
            return CreatedAtAction(nameof(GetKeyboards),new{empId=newKeyboard.empId,keyId=newKeyboard.keyId},newKeyboard);
        }
        [HttpPut("Employees/{empId}/Keyboards/{keyId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateKeyboard(string empId,string keyId,[FromBody] Keyboard keyboard){
            await deviceService.UpdateKeyboardAsync(keyId,keyboard);
            return NoContent();
        }
        [HttpDelete("Employees/{empId}/Keyboards/{keyId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteKeyboard(string empId, string keyId){
            await deviceService.DeleteKeyboardAsync(keyId);
            return NoContent();
        }

        // Mouses
        [HttpGet("Employees/{empId}/Mouses")]
        [Authorize]
        public async Task<IActionResult> GetMouses(string empId){
            var mouses=await deviceService.GetMousesByEmployeeAsync(empId);
            return Ok(mouses);
        }
        [HttpPost("Employees/{empId}/Mouses")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateMouse(string empId,[FromBody] Mouse mouse){
            mouse.empId=empId;
            var newMouse=await deviceService.CreateMouseAsync(mouse);
            return CreatedAtAction(nameof(GetMouses),new{empId=newMouse.empId,mouseId=newMouse.mouseId},newMouse);
        }
        [HttpPut("Employees/{empId}/Mouses/{mouseId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateMouse(string empId,string mouseId,[FromBody] Mouse mouse){
            await deviceService.UpdateMouseAsync(mouseId, mouse);
            return NoContent();
        }
        [HttpDelete("Employees/{empId}/Mouses/{mouseId}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteMouse(string empId, string mouseId){
            await deviceService.DeleteMouseAsync(mouseId);
            return NoContent();
        }
    }
}