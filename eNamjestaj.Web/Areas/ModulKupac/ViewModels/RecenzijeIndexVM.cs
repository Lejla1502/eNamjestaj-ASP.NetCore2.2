using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulKupac.ViewModels
{
    public class RecenzijeIndexVM
    {
        public int ProizvodId { get; set; }

        public List<RecenzijeInfo> Recenzijes { get; set; }

        public class RecenzijeInfo
        {
            public string Sadrzaj { get; set; }
            public DateTime Datum { get; set; }
            public decimal Ocjena { get; set; }
            public string ImeKupca { get; set; }
        }
    }
}
