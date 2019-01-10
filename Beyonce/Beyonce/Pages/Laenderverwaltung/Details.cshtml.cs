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
    public class DetailsModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public DetailsModel(Beyonce.Models.masterContext context)
        {
            _context = context;
        }

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
    }
}
