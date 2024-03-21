using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Consolejeu
{
    public class EditModel : PageModel 
    {
        private readonly IConsoleJeux _client;

        public EditModel(IConsoleJeux client)
        {
            _client = client;
        }

        [BindProperty]
        public ConsoleJeu ConsoleJeu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsoleJeu = await _client.ConsoleJeuxGETAsync(id.Value);

            if (ConsoleJeu == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _client.ConsoleJeuxPUTAsync(ConsoleJeu.Id, ConsoleJeu);
            }
            catch (Exception)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
