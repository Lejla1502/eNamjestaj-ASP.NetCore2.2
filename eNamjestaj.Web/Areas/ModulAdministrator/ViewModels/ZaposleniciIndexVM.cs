using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulAdministrator.ViewModels
{
    public class ZaposleniciIndexVM
    {
        public List<KorisnikInfo> Zaposlenici { get; set; }


        public class KorisnikInfo
        {
            public int ZaposlenikId { get; set; }
            public string KorisnickoIme { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Uloga { get; set; }
        }
    }
}
