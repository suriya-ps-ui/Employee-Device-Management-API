namespace Model{
    public class Mouse{
        public string empId{get;set;}
        public string mouseId{get;set;}
        public int mouseS_No{get;set;}
        public string mouseBrand{get;set;}
        public string status{get;set;}
        //Relation
        public virtual Employee Employee{get;set;}
        public Mouse(){}
        public Mouse(string empId,string mouseId,int mouseS_No,string mouseBrand,string status){
            this.empId=empId;
            this.mouseId=mouseId;
            this.mouseS_No=mouseS_No;
            this.mouseBrand=mouseBrand;
            this.status=status;
        }
    }
}