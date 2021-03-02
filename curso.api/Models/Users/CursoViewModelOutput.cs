using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Users
{
    public class CursoViewModelOutput
    {
        public string Nome {get; set;}
        public string Descricao { get; set;}
        public string Login { get; set;}

    }
}