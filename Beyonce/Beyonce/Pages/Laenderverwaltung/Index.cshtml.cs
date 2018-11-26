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
    public class IndexModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public IndexModel(Beyonce.Models.masterContext context)
        {
            _context = context;
        }

        public IList<Land> Land { get;set; }

        public async Task OnGetAsync()
        {
            Land = await _context.Land.ToListAsync();
        }
    }
}
