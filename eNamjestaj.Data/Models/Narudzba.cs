using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Narudzba
    {
        public int Id { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool Aktivna { get; set; }
        public bool Otkazano { get; set; }
        public bool NaCekanju { get; set; }

        public int KupacId { get; set; }
        public virtual Kupac Kupac { get; set; }
        
        public virtual Izlaz Izlaz { get; set; }

        
    }
}
