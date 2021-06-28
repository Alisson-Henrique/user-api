using System;
using System.Collections.Generic;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities{
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
            _errors = new List<string>();
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


        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.isValid){
                foreach(var erro in validation.Errors)
                    _errors.Add(erro.ErrorMessage);

                throw new Exception("Erro: " + _errors[0]);
            }

            return true;
        }
    }

}