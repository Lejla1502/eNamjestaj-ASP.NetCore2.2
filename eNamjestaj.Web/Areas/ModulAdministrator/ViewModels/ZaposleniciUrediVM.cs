using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulAdministrator.ViewModels
{
    public class ZaposleniciUrediVM
    {
        public int ZaposlenikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Molimo unesite korisnicko ime")]
        [MaxLength(16)]
        [MinLength(3, ErrorMessage = "Korisnicko ime mora sadrzavati minimalno 3 karaktera")]

        [Remote(action: "VerifyUsername", controller: "Zaposlenici", areaName: "ModulAdministrator", AdditionalFields = "ZaposlenikId")]
        public string KorisnickoIme { get; set; }
        
        [Required(ErrorMessage = "Obavezno je odabrati ulogu")]
        public int UlogaID { get; set; }
        public List<Uloga> Uloge { get; set; }
    }
}
