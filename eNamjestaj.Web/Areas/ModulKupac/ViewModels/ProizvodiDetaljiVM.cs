using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulKupac.ViewModels
{
    public class ProizvodiDetaljiVM
    {
        public string Slika { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
        //public int? Popust { get; set; } = 0;
        //public decimal? KonacnaCijena { get; set; } = 0;
        public List<SelectListItem> Boje { get; set; }
        public int BojaID { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [Range(1, 100, ErrorMessage = "Unesite cifru između 1 i 100")]
        public int kol { get; set; }
        public string Vrsta { get; set; }
        public int ProizvodId { get; set; }
        public string Boja { get; set; }
        public int Brojac { get; set; }
    }
}
