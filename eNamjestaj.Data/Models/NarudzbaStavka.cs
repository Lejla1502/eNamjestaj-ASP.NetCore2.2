using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class NarudzbaStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }

        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        public int NarudzbaId { get; set; }
        public virtual Narudzba Narudzba { get; set; }

        public int BojaId { get; set; }
        public virtual Boja Boja { get; set; }

        public decimal CijenaProizvoda { get; set; }

        public int PopustNaCijenu { get; set; } = 0;

        public decimal TotalStavke { get; set; }
    }
}
