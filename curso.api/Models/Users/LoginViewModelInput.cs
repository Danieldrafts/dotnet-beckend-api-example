using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login {get; set;}

        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set;}
    }
}