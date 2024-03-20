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
    public class DetailsModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public DetailsModel(IConsoleJeux client)
        {
            _client = client;
        }

        public Ventes Ventes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ventes = await _client.VentesGETAsync(id.Value );
            if (Ventes == null)
            {
                return NotFound();
            }
            else
            {
                Ventes = Ventes;
            }
            return Page();
        }
    }
}
