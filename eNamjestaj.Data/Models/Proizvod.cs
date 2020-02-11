using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Slika { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int VrstaProizvodaId { get; set; }
        public virtual VrstaProizvoda VrstaProizvoda { get; set; }

      //  public ICollection<ProizvodBoja> ProizvodBojas { get; set; }
        //public int BojaId { get; set; }
        //public Boja Boja { get; set; }
    }
}
