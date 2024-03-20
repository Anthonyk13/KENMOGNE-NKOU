using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetC_.Models;

namespace ProjetC_.Data
{
    public class ProjetC_Context : DbContext
    {
        public ProjetC_Context (DbContextOptions<ProjetC_Context> options)
            : base(options)
        {
        }

        public DbSet<ProjetC_.Models.ConsoleJeu> ConsoleJeu { get; set; } = default!;
        public DbSet<ProjetC_.Models.Ventes> Ventes { get; set; } = default!;

       
        
    }
}
