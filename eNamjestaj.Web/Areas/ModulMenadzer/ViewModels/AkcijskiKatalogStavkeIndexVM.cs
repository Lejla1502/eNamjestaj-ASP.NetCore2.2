using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class AkcijskiKatalogStavkeIndexVM
    {
        public int KatalogId { get; set; }
        public List<ProizvodiInfo> KatalogProizvodi { get; set; }

        public class ProizvodiInfo
        {
            public int Id { get; set; }
            public string Proizvod { get; set; }
            public decimal Cijena { get; set; }
            public int Procenat { get; set; }
            public decimal KonacnaCijena { get; set; }
        }
    }
}
