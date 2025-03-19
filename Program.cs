using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Register DbContext with Dependency Injection
builder.Services.AddDbContext<AssetManagementContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionString:DefaultString"]));
var app = builder.Build();
// Example middleware or endpoint to test it
app.MapGet("/", async (AssetManagementContext db) =>
{
    var employees = await db.Employees.ToListAsync();
    return "Hello World!";
});
app.Run();