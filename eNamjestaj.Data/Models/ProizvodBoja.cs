using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class ProizvodBoja
    {
        [Key]
        public int BojaId { get; set; }
        public virtual Boja Boja { get; set; }

        [Key]
        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
