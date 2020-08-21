using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class NarudzbaStavkeIndexVM
    {
        public int NarudzbaID { get; set; }
        public List<SelectListItem> nacinDostave { get; set; }
        public List<NarudzbaInfo> proizvodiNarudzbe { get; set; }
        public string SumTotal { get; set; }

        public class NarudzbaInfo
        {
            public int NarudzbastavkaID { get; set; }
            public string Proizvod { get; set; }
            public string VrstaProizvoda { get; set; }
            public string Boja { get; set; }
            public string Cijena { get; set; }

            public int Kolicina { get; set; }
            public string Total { get; set; }
            public string Popust { get; set; }
            public string KonacnaCijena { get; set; }

        }
    
}
}
