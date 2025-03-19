namespace Model{
    public class Keyboard{
        public string empId{get;set;}
        public string keyId{get;set;}
        public int keyS_No{get;set;}
        public string keyBrand{get;set;}
        public string status{get;set;}
        //Relationship
        public virtual Employee Employee{get;set;}
        public Keyboard(){}
        public Keyboard(string empId,string keyId,int keyS_No,string keyBrand,string status){
            this.empId=empId;
            this.keyId=keyId;
            this.keyS_No=keyS_No;
            this.keyBrand=keyBrand;
            this.status=status;
        }
    }
}