using Microsoft.EntityFrameworkCore;
using Model;

namespace Data{
    public class AssetManagementContext:DbContext{
        public DbSet<Employee> Employees{get;set;}
        public DbSet<Laptop> Laptops{get;set;}
        public DbSet<Mouse> Mouses{get;set;}
        public DbSet<Keyboard> Keyboards{get;set;}
        public AssetManagementContext(DbContextOptions<AssetManagementContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasDefaultSchema("AssetManagement");
            modelBuilder.Entity<Employee>(Employee=>{
                Employee.HasKey(e=>e.empId);
                Employee.Property(e=>e.empName).IsRequired();
                Employee.Property(e=>e.department).IsRequired();
            });
            modelBuilder.Entity<Laptop>(Laptop=>{
                Laptop.HasKey(l=>new {l.empId,l.lapHostName});
                Laptop.HasOne(l=>l.Employee).WithMany(e=>e.Laptops).HasForeignKey(l=>l.empId);
            });
            modelBuilder.Entity<Keyboard>(Keyboard=>{
                Keyboard.HasKey(k=>k.keyId);
                Keyboard.HasOne(k=>k.Employee).WithMany(e=>e.Keyboards).HasForeignKey(k=>k.empId);
            });
            modelBuilder.Entity<Mouse>(Mouse=>{
                Mouse.HasKey(m=>m.mouseId);
                Mouse.HasOne(m=>m.Employee).WithMany(e=>e.Mouses).HasForeignKey(m=>m.empId);
            });
        }
    }
}