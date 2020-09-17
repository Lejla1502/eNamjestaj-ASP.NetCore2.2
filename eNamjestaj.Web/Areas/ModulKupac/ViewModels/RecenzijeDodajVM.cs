using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulKupac.ViewModels
{
    public class RecenzijeDodajVM
    {
        public int ProizvodId { get; set; }
        [Required(ErrorMessage ="Obavezno je unijeti ocjenu")]
        public int OcjenaId { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti ocjenu")]
        [Range(0.5,5.0)]
        public decimal Ocjena { get; set; }
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti komentar")]
        [MinLength(5, ErrorMessage = "Komentar mora sadrzavati minimalno 5 karaktera")]
        public string Sadrzaj { get; set; }
    }
}
