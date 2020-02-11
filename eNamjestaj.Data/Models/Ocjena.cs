using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class Ocjena
    {

        public int Id { get; set; }
        public int OcjenaBr { get; set; }
        public DateTime Datum { get; set; }
        public int KupacId { get; set; }
        public virtual Kupac Kupac { get; set; }
    }
}
