using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Vente
{
    public class EditModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public EditModel(IConsoleJeux client)
        {
            _client = client;
        }

        [BindProperty]
        public Ventes Ventes { get; set; } = default!;

       
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _client.VentesPUTAsync(Ventes.Id, Ventes);
                await _client.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }


            return RedirectToPage("./Index");

        }
       
    }
}
