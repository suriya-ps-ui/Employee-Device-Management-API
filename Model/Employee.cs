namespace Model{
    public class Employee{
        public string empId{get;set;}
        public string empName{get;set;}
        public string department{get;set;}
        //Relationships
        public virtual ICollection<Laptop> Laptops {get;set;}=new List<Laptop>();
        public virtual ICollection<Keyboard> Keyboards{get;set;}=new List<Keyboard>();
        public virtual ICollection<Mouse> Mouses{get;set;}=new List<Mouse>();
        public Employee(){}
        public Employee(string empId,string empName,string department){
            this.empId=empId;
            this.empName=empName;
            this.department=department;
        }
    }
}