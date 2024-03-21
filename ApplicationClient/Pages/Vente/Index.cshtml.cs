using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ApplicationClient.API;

namespace ApplicationClient.Pages.Vente
{
    public class IndexModel : PageModel
    {
        private readonly IConsoleJeux _client;

        public IndexModel(IConsoleJeux client)
        {
            _client = client;
        }

        public IList<Ventes> Ventes { get;set; } = default!;

        public async Task OnGETAsync()
        {
            Ventes = (await _client.VentesAllAsync()).ToList();
           
        }
    }
}
