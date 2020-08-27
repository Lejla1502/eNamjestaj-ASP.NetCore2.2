using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class NarudzbeDetaljiVM
    {
        public int NarudzbaID { get; set; }
        public List<NarudzbeStavkeInfo> DetaljiNarudzbe { get; set; }
        public string SumTotal { get; set; }

        public class NarudzbeStavkeInfo
        {
            public int StavkaId { get; set; }
            public string Proizvod { get; set; }
            public string Cijena { get; set; }
            public int Kolicina { get; set; }
            public string Boja { get; set; }
            public string Dostava { get; set; }
            public string Total { get; set; }
        }
    }
}
