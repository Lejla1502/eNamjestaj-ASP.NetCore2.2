using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class IzlazStavka
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Popust { get; set; }
        public int Kolicina { get; set; }
        public decimal Konacnacijena { get; set; }

        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        public int IzlazId { get; set; }
        public virtual Izlaz Izlaz { get; set; }
    }
}
