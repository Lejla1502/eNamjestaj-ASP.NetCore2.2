using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Molimo unesite korisničko ime"), DataType(DataType.Text), MaxLength(50),
           MinLength(3, ErrorMessage = "Korisničko ime mora imati minimalno tri karaktera")]
        public string username { get; set; }
        [Required(ErrorMessage = "Molimo unesite šifru"),
            MaxLength(14), MinLength(3, ErrorMessage = "Šifra mora imati minimalno 3 karaktera")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
