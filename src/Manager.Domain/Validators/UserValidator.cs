using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators{


    public class UserValidator : AbstractValidator<User>{


        public UserValidator(){
            
            RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Usuario não pode ser vazio.")

            .NotNull()
            .WithMessage("Usuario não pode ser nulo.");
       

            RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username não pode estar vazio.")

            .NotNull()
            .WithMessage("Username não pode estar nulo.")

            .MinimumLength(3)
            .WithMessage("Username deve ter no minimo 3 letras.")

            .MaximumLength(1056)
            .WithMessage("Username deve ter no máximo 1056 letras.");
            

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email não pode estar vazio.")

            .NotNull()
            .WithMessage("Email não pode estar nulo.")

            .MinimumLength(10)
            .WithMessage("Email deve ter no minimo 10 caracters.")

            .MaximumLength(1056)
            .WithMessage("Email deve ter no máximo 50 letras.")

            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("O email informado não é válido.");


            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("A senha não pode estar vazio.")

            .NotNull()
            .WithMessage("A senha não pode estar nulo.")

            .MinimumLength(6)
            .WithMessage("A senha deve ter no minimo 6 letras.")

            .MaximumLength(30)
            .WithMessage("A senha deve ter no máximo 30 letras.");
        }

    }
}