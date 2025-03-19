namespace Model{
    public class Laptop{
        string empId{get;set;}
        string lapHostName{get;set;}
        string lapModel{get;set;}
        string processor{get;set;}
        string storage{get;set;}
        string ram{get;set;}
        DateOnly assignedOn{get;set;}
        string status{get;set;}

        //Relationships
        public virtual Employee Employee{get;set;}
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