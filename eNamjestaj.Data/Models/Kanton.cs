using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Kanton
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public int DrzavaId { get; set; }
        public virtual Drzava Drzava { get; set; }
    }
}
