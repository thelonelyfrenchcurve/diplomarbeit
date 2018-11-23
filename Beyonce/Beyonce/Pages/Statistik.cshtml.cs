using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beyonce.Statistik;
namespace Beyonce.Statistik
{
    public class LandModel
    {
        public IList<Land> landListe = new List<Land>();
        public LandModel()
        {
            landListe.Add(new Land("Deutschland", 13));
            landListe.Add(new Land("Schweiz", 11));
            landListe.Add(new Land("Oesterreich", 123));
        }
    }
}
