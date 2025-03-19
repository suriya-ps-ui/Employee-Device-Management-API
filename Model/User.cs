namespace Model{
    public class User{
        public int id{get;set;}
        public string userName{get;set;}
        public string password{get;set;}
        public string role{get;set;}
        public string empId{get;set;}
        //Relation
        public virtual Employee Employee{get;set;}
    }
}