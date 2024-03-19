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
    public class IndexModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public IndexModel(IConsoleJeux client)
        {
            _client = client;
        }

        public IList<ConsoleJeu> ConsoleJeu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ConsoleJeu = (await _client.ConsoleJeuxAllAsync()).ToList();
        }
    }
}
