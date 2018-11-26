using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beyonce.Models;

namespace Beyonce.Pages.Laenderverwaltung
{
    public class CreateModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public CreateModel(Beyonce.Models.masterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Land Land { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Land.Add(Land);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}