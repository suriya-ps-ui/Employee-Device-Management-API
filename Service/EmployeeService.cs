using Data;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services{
    public class EmployeeService:IEmployeeService{
        AssetManagementContext assetManagementContext;
        public EmployeeService(AssetManagementContext assetManagementContext){
            this.assetManagementContext=assetManagementContext;
        }
        public async Task<List<Employee>> GetAllEmployeesAsync(){
            return await assetManagementContext.Employees.Include(e=>e.Laptops).Include(e=>e.Mouses).Include(e=>e.Keyboards).ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIDAsync(string id){
            return await assetManagementContext.Employees.Include(e=>e.Laptops).Include(e=>e.Mouses).Include(e=>e.Keyboards).FirstOrDefaultAsync(e=>e.empId==id);
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee){
            assetManagementContext.Employees.Add(employee);
            await assetManagementContext.SaveChangesAsync();
            return employee;
        }
        public async Task UpdateEmployeeAsync(string id,Employee employee){
            var emp=await assetManagementContext.Employees.FirstOrDefaultAsync(e=>e.empId==id);
            if(emp==null){
                throw new Exception("Employee not found.");
            }
            emp.empName=employee.empName;
            emp.department=employee.department;
            await assetManagementContext.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(string id){
            var employee=await assetManagementContext.Employees.FirstOrDefaultAsync(e=>e.empId==id);
            if(employee==null){
                throw new Exception("Employee not found.");
            }
            assetManagementContext.Remove(employee);
            await assetManagementContext.SaveChangesAsync();
        }
    }
}