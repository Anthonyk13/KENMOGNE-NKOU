using System.Threading.Tasks;
using ApplicationClient.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApplicationClient.Pages.Consolejeu
{
    public class DetailsModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public DetailsModel(IConsoleJeux client)
        {
            _client = client;
        }

        public ConsoleJeu ConsoleJeu { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Récupérer les données de la console de jeu depuis l'API
            ConsoleJeu = await _client.ConsoleJeuxGETAsync(id.Value);

            // Vérifier si la console de jeu existe
            if (ConsoleJeu == null)
            {
                return NotFound();
            }

            // Retourner la vue des détails de la console de jeu
            return Page();
        }
    }
}
