using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class RadniNalog
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        public int? NarudzbaId { get; set; }
        public virtual Narudzba Narudzba { get; set; }

        public int DostavljacId { get; set; }
        public virtual Dostavljac Dostavljac { get; set; }
    }
}
