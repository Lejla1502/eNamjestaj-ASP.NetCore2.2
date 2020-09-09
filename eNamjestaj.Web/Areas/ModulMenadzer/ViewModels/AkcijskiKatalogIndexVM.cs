using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class AkcijskiKatalogIndexVM
    {
        public List<KatalogInfo> Katalozi { get; set; }
        public bool daLiJeIjedanKatalogAktivan { get; set; }

        public class KatalogInfo
        {
            public int Id { get; set; }
            public string Opis { get; set; }
            public DateTime DatumPocetka { get; set; }
            public DateTime DatumZavrsetka { get; set; }
            public bool Aktivan { get; set; }
        }
    }
}
