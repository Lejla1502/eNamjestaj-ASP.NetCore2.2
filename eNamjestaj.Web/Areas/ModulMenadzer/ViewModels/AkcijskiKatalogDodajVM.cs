using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class AkcijskiKatalogDodajVM
    {
        [Required(ErrorMessage = "Opis je neophodan")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Datum pocetka je neophodno naznaciti")]
        [DataType(DataType.Date)]
        public DateTime? DatumPocetka { get; set; }
        [Required(ErrorMessage = "Datum zavrsetka je neophodno naznaciti")]
        [DataType(DataType.Date)]
        public DateTime? DatumZavrsetka { get; set; }
        public bool Aktivan { get; set; }
    }
}
