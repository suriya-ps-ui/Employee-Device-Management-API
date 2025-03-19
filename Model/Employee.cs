namespace Model{
    public class Employee{
        public string empId{get;set;}
        public string empName{get;set;}
        public string departmemt{get;set;}
        //Relationships
        public virtual ICollection<Laptop> Laptops {get;set;}=new List<Laptop>();
        public virtual ICollection<Keyboard> Keyboards{get;set;}=new List<Keyboard>();
        public virtual ICollection<Mouse> Mouses{get;set;}=new List<Mouse>();
        public Employee(){}
        public Employee(string empId,string empName,string departmemt){
            this.empId=empId;
            this.empName=empName;
            this.departmemt=departmemt;
        }
    }
}