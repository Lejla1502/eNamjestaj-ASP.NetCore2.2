using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class ProizvodiIndexVM
    {
        public List<ProizvodiInfo> Proizvodi { get; set; }

        public List<SelectListItem> Vrste { get; set; }
        public List<SelectListItem> Boje { get; set; }

        public class ProizvodiInfo
        {
            public int Id { get; set; }
            public decimal Cijena { get; set; }
            public string Naziv { get; set; }
            public string Sifra { get; set; }
            public string Slika { get; set; }
            public int? Popust { get; set; }
            public decimal? KonacnaCijena { get; set; }
            public string Boja { get; set; }
            public int BrojacBoja { get; set; }
        }
    }
}
