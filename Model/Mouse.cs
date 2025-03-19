namespace Model{
    public class Mouse{
        string empId{get;set;}
        string mouseId{get;set;}
        int mouseS_No{get;set;}
        string mouseBrand{get;set;}
        string status{get;set;}

        //Relation
        public virtual Employee Employee{get;set;}
        public Mouse(string empId,string mouseId,int mouseS_No,string mouseBrand,string status){
            this.empId=empId;
            this.mouseId=mouseId;
            this.mouseS_No=mouseS_No;
            this.mouseBrand=mouseBrand;
            this.status=status;
        }
    }
}