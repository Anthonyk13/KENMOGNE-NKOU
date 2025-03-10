﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationClient.API;

namespace ApplicationClient.Pages.Consolejeu
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
        public ConsoleJeu ConsoleJeu { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _client.ConsoleJeuxPOSTAsync(ConsoleJeu);
                
            }
            catch (Exception)
            {
                return RedirectToPage("./Index");
            }
           

            return RedirectToPage("./Index");
        }
    }
}
