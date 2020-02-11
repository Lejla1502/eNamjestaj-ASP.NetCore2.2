using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class AkcijskiKatalog
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool Aktivan { get; set; }
    }
}
