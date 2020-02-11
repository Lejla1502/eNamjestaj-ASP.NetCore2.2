using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Ulaz
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
        public string Napomena { get; set; }
        public decimal PDV { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int SkladisteId { get; set; }
        public virtual Skladiste Skladiste { get; set; }
    }
}
