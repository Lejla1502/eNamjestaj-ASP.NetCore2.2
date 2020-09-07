using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulKupac.ViewModels
{
    public class DostavaIndexVM
    {
        public List<DostavaInfo> Dostave { get; set; }
        public int NarudzbaID { get; set; }
        public string Total { get; set; }
        [Required(ErrorMessage = "select any one option")]
        public string dostava { get; set; }

        public class DostavaInfo
        {
            [Required(ErrorMessage = "Molimo odaberite tip")]
            public int Id { get; set; }
            public string Tip { get; set; }
            public string Cijena { get; set; }
            public string Opis { get; set; }

        }
    }
}
