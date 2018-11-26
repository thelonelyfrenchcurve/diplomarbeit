using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beyonce.Models;

namespace Beyonce.Pages.Laenderverwaltung
{
    public class EditModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public EditModel(Beyonce.Models.masterContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Land).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandExists(Land.LandId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LandExists(int id)
        {
            return _context.Land.Any(e => e.LandId == id);
        }
    }
}
