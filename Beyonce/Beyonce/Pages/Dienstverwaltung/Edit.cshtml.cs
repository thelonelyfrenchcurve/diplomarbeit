using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beyonce.Models;

namespace Beyonce.Pages.Dienstverwaltung
{
    public class EditModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public EditModel(Beyonce.Models.masterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dienst Dienst { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dienst = await _context.Dienst.FirstOrDefaultAsync(m => m.DienstId == id);

            if (Dienst == null)
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

            _context.Attach(Dienst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DienstExists(Dienst.DienstId))
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

        private bool DienstExists(int id)
        {
            return _context.Dienst.Any(e => e.DienstId == id);
        }
    }
}
