using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace Services{
    public class AuthService:IAuthService{
        AssetManagementContext assetManagementContext;
        IConfiguration configuration;
        public AuthService(AssetManagementContext assetManagementContext,IConfiguration configuration){
            this.assetManagementContext=assetManagementContext;
            this.configuration=configuration;
        }
        public async Task<string> LoginAsync(string username,string password){
            var user=assetManagementContext.Users.FirstOrDefault(u=>u.userName==username && u.password==password);
            if (user==null){
                throw new Exception("Invalid credentials");
            }
            var claims=new[]{
                new Claim(ClaimTypes.Name,user.userName),
                new Claim(ClaimTypes.Role,user.role),
                new Claim("EmpId",user.empId??"")
            };
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token=new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddHours(1),
                signingCredentials:creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task RegisterUserAsync(string username,string pass,string Role,string Id=null){
            if(await assetManagementContext.Users.AnyAsync(u=>u.userName==username)){
                throw new Exception("Username already exists");
            }
            var user=new User{
                userName=username,
                password=pass,
                role=Role,
                empId=Id
            };
            assetManagementContext.Users.Add(user);
            await assetManagementContext.SaveChangesAsync();
        }
    }
}