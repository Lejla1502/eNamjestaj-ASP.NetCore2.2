using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class AkcijskiKatalogStavkeDodajVM
    {
        public int KatalogID { get; set; }
        [Required(ErrorMessage = "Neophodno je odabrati proizvod")]
        public int ProizvodID { get; set; }
        public List<SelectListItem> Proizvodi { get; set; }
        [Required(ErrorMessage = "Neophodno je unijeti procenat")]
        [Range(5, 100, ErrorMessage = "Unesite procent u rasponu od 5 do 100")]
        public int Procenat { get; set; }
    }
}
