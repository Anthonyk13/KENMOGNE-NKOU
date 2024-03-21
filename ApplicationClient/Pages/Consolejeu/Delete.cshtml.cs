using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Consolejeu
{
    public class DeleteModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public DeleteModel(IConsoleJeux client)
        {
            _client = client;
        }

        [BindProperty]
        public ConsoleJeu ConsoleJeu { get; set; } = default!;

        /*public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ConsoleJeu = await _client.ConsoleJeuxGETAsync(id.Value);
           if(ConsoleJeu == null)
            {
                return NotFound();
            }
           else
            {
                ConsoleJeu = ConsoleJeu;
            }


            return Page();
        }*/
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _client.ConsoleJeuxDELETEAsync(id.Value);
            }
            catch (Exception)
            {
                return RedirectToPage("./Index");
            }
            

            return RedirectToPage("./Index");
        }
    }
}
