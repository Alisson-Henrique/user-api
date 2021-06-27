namespace User.Domain.Entities{


    public class User : Base{
       
        public string Username{ get; private set; }  
        public string Email { get; private set; }  
        public string Password { get; private set; }

        //Entitie FrameWork
        protected User(){}
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public void ChangeName(string username){
            Username = username;
            Validate(); 
        }
         public void ChangeEmail(string email){
            Email = email;
            Validate(); 
        }
         public void ChangePassword(string password){
            Password = password;
            Validate(); 
        }
        
    }

}