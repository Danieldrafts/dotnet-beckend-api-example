using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Users
{
    public class UserViewModelOutput
    {
        public int Codigo {get; set;}
        public string Login {get; set;}
        public string Email { get; set;}
    }
}