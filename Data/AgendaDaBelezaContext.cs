using Microsoft.EntityFrameworkCore;
using Agenda_da_Beleza_API.Models;

namespace Agenda_da_Beleza_API.Data
{
    public class AgendaDaBelezaContext: DbContext
    {
        public AgendaDaBelezaContext(DbContextOptions<AgendaDaBelezaContext> options): base (options)
        {
        }

        public DbSet<Cliente> Cliente {get; set;}  

        public DbSet<Salao> Salao {get; set;}  
        
        public DbSet<Servicos> Servicos {get; set;}  

        public DbSet<Agendamento> Agendamento {get; set;} 
    }
}