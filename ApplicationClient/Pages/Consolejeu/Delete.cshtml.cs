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
        public ConsoleJeu ConsoleJeu { get; set; } 

      
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
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            

            return RedirectToPage("./Index");
        }
    }
}
