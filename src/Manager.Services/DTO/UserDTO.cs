namespace Manager.Services.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        
        public string Username{ get; set; }  
        
        public string Email { get; set; }  
        
        public string Password { get; set; }

        public UserDTO()
        { }
        public UserDTO(long id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

    }
}