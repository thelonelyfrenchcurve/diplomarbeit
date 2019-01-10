using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beyonce.Models;

namespace Beyonce.Pages.Laenderverwaltung
{
    public class DeleteModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public DeleteModel(Beyonce.Models.masterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Land Land { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Land = await _context.Land.FirstOrDefaultAsync(m => m.LandId == id);

            if (Land == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Land = await _context.Land.FindAsync(id);

            if (Land != null)
            {
                _context.Land.Remove(Land);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
