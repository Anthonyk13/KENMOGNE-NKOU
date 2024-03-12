
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetC_.Data;
using System;
using System.Linq;
namespace ProjetC_.Models;
public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProjetC_Context(
        serviceProvider.GetRequiredService<
        DbContextOptions<ProjetC_Context>>()))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // S’il y a déjà des films dans la base
            if (context.ConsoleJeu.Any())
            {
                return; // On ne fait rien
            }
            // Sinon on en ajoute un
            context.ConsoleJeu.AddRange(
            new ConsoleJeu
            {
                GameModel="PS",
                Price=1500,
                ConstructorName="Sony"
            }
            );
            context.SaveChanges();
        }
    }
}