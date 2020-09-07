using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class ProizvodiUrediVM
    {
        public int ProizvodId { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti naziv proizvoda")]
        [MinLength(3, ErrorMessage = "Naziv mora sadrzavati minimalno 3 karaktera")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti sifru proizvoda")]
        [RegularExpression(@"^(\d{1,8})\b", ErrorMessage = "Potrebno je unijeti broj u rasponu 1-8 ")]
        [Remote(action: "VerifySifra", controller: "ProizvodiMenadzer", AdditionalFields = "ProizvodId")] //ne zaboravi dodati AREANAme
        public string Sifra { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti cijenu proizvoda")]

        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "Potrebno je unijeti decimalni broj")]
        public string Cijena { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati vrstu proizvoda")]
        public int VrstaID { get; set; }
        public List<VrstaProizvoda> Vrste { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati boju")]
        public int[] BojeID { get; set; }
        public SelectList Boje { get; set; }

        public string Slika { get; set; }

        [Display(Name = "Upload slike")]
        public IFormFile UploadPic { get; set; }

    }
}
