using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Dostava
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
    }
}
