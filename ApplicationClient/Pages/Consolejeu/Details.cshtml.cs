using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationClient.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Consolejeu
{
    public class DetailsModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public DetailsModel(IConsoleJeux client)
        {
            _client = client;
        }


        public ConsoleJeu ConsoleJeu { get; set; } = default!;

        public async Task<IActionResult> OnGETAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
             ConsoleJeu = await _client.ConsoleJeuxGET(id);
            if (ConsoleJeu == null)
            {
                return NotFound();
            }
            else
            {
                ConsoleJeu = ConsoleJeu;
            }
            return Page();
        }
        
    }
}
