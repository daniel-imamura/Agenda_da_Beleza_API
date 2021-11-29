using System.ComponentModel.DataAnnotations;

namespace Agenda_da_Beleza_API.Models
{
    public class Servicos
    {
        [Key]  
        public int IdServicos { get; set; }        

        [Required(ErrorMessage = "Este campo é obrigatório")]        
        public int IdSalao { get; set; }

        public decimal AlongamentoDeCilios { get; set; }
        
        public decimal Maquiagem { get; set; }

        public decimal Tintura { get; set; }
        
        public decimal CorteDeCabelo { get; set; }
        
        public decimal Penteado { get; set; }

        public decimal Progressiva { get; set; }

        public decimal Luzes { get; set; }

        public decimal LimpezaDePele { get; set; }

        public decimal DesignDeSobrancelha { get; set; }

        public decimal Hidratacao { get; set; }

        public decimal Unha { get; set; }
    }
}