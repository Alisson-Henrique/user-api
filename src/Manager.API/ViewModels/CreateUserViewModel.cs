using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels{


    public class CreateUserViewModel{

        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "Username deve ter no minimo 3 letras")]
        [MaxLength(80, ErrorMessage = "Username deve ter no máximo 1056 caracteres.")]

        public string Username{ get; set; }  
        [Required(ErrorMessage = "Email não pode estar vazio.")]
        [MinLength(10,ErrorMessage = "Email deve ter no minimo 10 caracters.")]
        [MaxLength(50,ErrorMessage = "Email deve ter no máximo 50 letras.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }  

        [Required(ErrorMessage = "A senha não pode estar vazio.")]
        [MinLength(3, ErrorMessage = "A senha deve ter no minimo 6 letras.")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 30 letras.")]
        public string Password { get; set; }
    }


}