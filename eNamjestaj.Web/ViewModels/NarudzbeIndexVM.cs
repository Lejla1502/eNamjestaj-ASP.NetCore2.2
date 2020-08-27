using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class NarudzbeIndexVM
    {
        public List<NarudzbeInfo> Narudzbe { get; set; }

        public class NarudzbeInfo
        {
            public int NarudzbaId { get; set; }
            public DateTime Datum { get; set; }
            public string UkupanIznos { get; set; }
            public bool Status { get; set; }
            public bool Otkazana { get; set; }
            public bool Kompletirana { get; set; }
            public bool Trenutna { get; set; }

        }
    }
}
