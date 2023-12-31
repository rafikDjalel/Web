using applicationWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace applicationWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        internal object Pilotes;
        internal object Avions;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        
        {
                
        }

        public DbSet<Avion> avion { get; set; }
        public DbSet<Pilote> pilote { get; set; }
        public DbSet<Vol> vol { get; set; }

       

    }
}
