using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Vente
{
    public class CreateModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public CreateModel(IConsoleJeux client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ventes Ventes { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try { await _client.VentesPOSTAsync(Ventes); 
            }catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            

            return RedirectToPage("./Index");
        }
    }
}
