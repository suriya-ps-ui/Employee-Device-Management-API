namespace Model{
    public class Keyboard{
        string empId{get;set;}
        string keyId{get;set;}
        int keyS_No{get;set;}
        string keyBrand{get;set;}
        string status{get;set;}

        //Relationship
        public virtual Employee Employee{get;set;}
        public Keyboard(string empId,string keyId,int keyS_No,string keyBrand,string status){
            this.empId=empId;
            this.keyId=keyId;
            this.keyS_No=keyS_No;
            this.keyBrand=keyBrand;
            this.status=status;
        }
    }
}