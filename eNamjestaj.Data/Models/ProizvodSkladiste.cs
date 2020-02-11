using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class ProizvodSkladiste
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int SkladisteId { get; set; }
        public int ProizvodId { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual Skladiste Skladiste { get; set; }
    }
}
