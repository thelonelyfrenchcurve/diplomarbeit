using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beyonce.Statistik
{
    public class Land
    {
        private String name;
        private int benutzerAnz;
        public Land(String name, int benutzerAnz)
        {
            this.name = name;
            this.benutzerAnz = benutzerAnz;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setBenutzerAnz(int anz)
        {
            this.benutzerAnz = anz;
        }
        public int getbenutzerAnz()
        {
            return benutzerAnz;
        }
        public String getName() {
            return name;
        }
    }
}
