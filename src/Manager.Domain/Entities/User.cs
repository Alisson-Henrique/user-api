using System;
using System.Collections.Generic;
using Manager.Core.Exceptions;
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
            Validate();
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

            if(!validation.IsValid)
            {
                foreach(var erro in validation.Errors)
                    _errors.Add(erro.ErrorMessage);

                throw new DomainException("Erro", _errors);
            }

            return true;
        }
    }

}