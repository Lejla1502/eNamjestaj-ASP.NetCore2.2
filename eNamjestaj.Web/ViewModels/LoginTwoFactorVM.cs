using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class LoginTwoFactorVM
    {
        [Required(ErrorMessage = "Polje je obavezno.")]
        [DisplayName("Dvofaktorni pin")]
        public string TwoFactorPin { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public bool ZapamtiLozinku { get; set; }
    }
}
