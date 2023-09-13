using Microsoft.EntityFrameworkCore;
using TP02___SWII6.Models;

namespace TP02___SWII6.Data
{
    public class ContextApplication : DbContext
    {
        public ContextApplication(DbContextOptions<ContextApplication> options) : base(options)
        {

        }

        public DbSet<DocumentoBL> DocumentosBL { get; set; }
        public DbSet<Conteiner> Conteiners { get; set; }
    }
}
