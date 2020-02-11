using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class KatalogStavka
    {
        public int Id { get; set; }

        public int PopustProcent { get; set; }

        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        public int AkcijskiKatalogId { get; set; }
        public virtual AkcijskiKatalog AkcijskiKatalog { get; set; }
    }
}
