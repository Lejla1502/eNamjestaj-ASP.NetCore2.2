using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulAdministrator.ViewModels
{
    public class KupciIndexVM
    {
        public List<KorisnikInfo> Kupci { get; set; }


        public class KorisnikInfo
        {
            public int KupacId { get; set; }
            public string KorisnickoIme { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
        }
    }
}
