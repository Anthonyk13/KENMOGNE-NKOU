using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Vente
{
    public class DeleteModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public DeleteModel(IConsoleJeux client)
        {
            _client = client;
        }

        [BindProperty]
        public Ventes Ventes { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ConsoleJeu = await _client.VentesGETAsync(id.Value);
            if (ConsoleJeu == null)
            {
                return NotFound();
            }
            else
            {
                Ventes = Ventes;
            }


            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ventes = await _client.VentesGETAsync(id.Value);
            if (Ventes != null)
            {
                Ventes = Ventes;
                _client.VentesDELETEAsync(id.Value);
                await _client.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
