using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Users
{
    public class RegisterViewModelInput
    {
        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login {get; set;}

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set;}
    }
}