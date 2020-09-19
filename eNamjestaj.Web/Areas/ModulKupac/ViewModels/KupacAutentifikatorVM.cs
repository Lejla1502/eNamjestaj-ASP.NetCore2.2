using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulKupac.ViewModels
{
    public class KupacAutentifikatorVM
    {
        [Required]
        public string TwoFactorCode { get; set; }

        [DisplayName("Dvofaktorni pin")]
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string TwoFactorPin { get; set; }

        public string TwoFactorUserUniqueKey { get; set; }

        public string TwoFactorBarcodeImage { get; set; }
    }
}
