using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class ProizvodiIndexMenadzerVM
    {
        public List<ProizvodiInfo> Proizvodi { get; set; }
        public List<SelectListItem> Vrste { get; set; }
        public int? vrstaID { get; set; }

        public class ProizvodiInfo
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string Sifra { get; set; }
            public string Cijena { get; set; }
            public string Slika { get; set; }
        }
    }
}
