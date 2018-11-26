using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beyonce.Models;

namespace Beyonce.Pages.Dienstverwaltung
{
    public class DeleteModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public DeleteModel(Beyonce.Models.masterContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dienst = await _context.Dienst.FindAsync(id);

            if (Dienst != null)
            {
                _context.Dienst.Remove(Dienst);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
