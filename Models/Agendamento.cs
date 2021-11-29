using System.ComponentModel.DataAnnotations;
using System;

namespace Agenda_da_Beleza_API.Models
{
    public class Agendamento
    {
        [Key]  
        public int IdAgendamento { get; set; }        

        [Required(ErrorMessage = "Este campo é obrigatório")]        
        public int IdCliente { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int IdSalao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve ter no máximo 50 caracteres")]

        public string Servico { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]                
        public DateTime dataAgendada { get; set; }
    }
}