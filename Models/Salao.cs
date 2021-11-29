using System.ComponentModel.DataAnnotations;

namespace Agenda_da_Beleza_API.Models
{
    public class Salao
    {
        [Key]  
        public int IdSalao { get; set; }        

        [Required(ErrorMessage = "Este campo é obrigatório")]        
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo deve ter no máximo 11 caracteres")]

        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; set; }
    }
}