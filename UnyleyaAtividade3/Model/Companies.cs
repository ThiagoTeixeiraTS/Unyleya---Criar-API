using System.ComponentModel.DataAnnotations;

namespace UnyleyaAtividade3.Model
{
    public class Companies
    {
        [Required(ErrorMessage = "Todos os campos são obrigatórios!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Todos os campos são obrigatórios!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Todos os campos são obrigatórios!")]
        public string Adress { get; set; }
    }
}
