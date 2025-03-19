namespace Model{
    public class Laptop{
        public string lapHostName{get;set;}
        public string empId{get;set;}
        public string lapModel{get;set;}
        public string processor{get;set;}
        public string storage{get;set;}
        public string ram{get;set;}
        public DateOnly assignedOn{get;set;}
        public string status{get;set;}
        //Relationships
        public virtual Employee Employee{get;set;}
        public Laptop(){}
        public Laptop(string empId,string lapHostName,string lapModel,string processor,string storage,string ram,DateOnly assignedOn,string status){
            this.empId=empId;
            this.lapHostName=lapHostName;
            this.lapModel=lapModel;
            this.processor=processor;
            this.storage=storage;
            this.ram=ram;
            this.assignedOn=assignedOn;
            this.status=status;
        }
    }
}