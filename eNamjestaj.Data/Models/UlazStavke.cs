using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class UlazStavke
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }

        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        public int UlazId { get; set; }
        public virtual Ulaz Ulaz { get; set; }
    }
}
