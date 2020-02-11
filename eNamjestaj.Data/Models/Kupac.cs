using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Kupac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }


        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
