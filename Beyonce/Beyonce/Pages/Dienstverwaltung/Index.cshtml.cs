using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beyonce.Models;
using System.Net.NetworkInformation;

namespace Beyonce.Pages.Dienstverwaltung
{
    public class IndexModel : PageModel
    {
        private readonly Beyonce.Models.masterContext _context;

        public IndexModel(Beyonce.Models.masterContext context)
        {
            _context = context;
        }

        public IList<Dienst> Dienst { get;set; }

        public async Task OnGetAsync()
        {
            Dienst = await _context.Dienst.ToListAsync();
        }

        public bool IsPingable(string nameOrAddress, bool throwExceptionOnError = false)
        {
            bool pingable = false;
            using (Ping pinger = new Ping())
            {
                try
                {
                    PingReply reply = pinger.Send(nameOrAddress,1);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException e)
                {
                    if (throwExceptionOnError) throw e;
                    pingable = false;
                }
            }
            return pingable;
        }
    }
}
