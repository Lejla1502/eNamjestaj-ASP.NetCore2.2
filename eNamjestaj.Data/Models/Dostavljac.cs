using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Dostavljac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string ZiroRacun { get; set; }


        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
