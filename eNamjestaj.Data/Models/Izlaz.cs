using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Izlaz
    {
        [Key]
        public int IzlazId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        
        public bool Zakljucena { get; set; }
        public decimal IznosBezPDV { get; set; }
        public decimal IznosSaPDV { get; set; }
        public bool PovratNovca { get; set; }

        public int SkladisteId { get; set; }
        public virtual Skladiste Skladiste { get; set; }

        public int? KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }


        public int NarudzbaId { get; set; }
        public virtual Narudzba Narudzba { get; set; }


        public int DostavaId { get; set; }
        public virtual Dostava Dostava { get; set; }
    }
}
