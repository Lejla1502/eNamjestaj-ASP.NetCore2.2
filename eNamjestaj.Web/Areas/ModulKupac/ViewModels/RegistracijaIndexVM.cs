using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulKupac.ViewModels
{
    public class RegistracijaIndexVM
    {
        [Required(ErrorMessage = "Molimo unesite korisnicko ime")]
        [MaxLength(16)]
        [MinLength(3, ErrorMessage = "Korisnicko ime mora sadrzavati minimalno 3 karaktera")]

        [Remote(action: "VerifyUsername", controller: "Registracija", areaName: "ModulKupac")]
        public string KorisnickoIme { get; set; }


        [Required(ErrorMessage = "Molimo unesite sifru"), DataType(DataType.Password),
            MaxLength(14), MinLength(3, ErrorMessage = "Sifra mora imati minimalno 3 karaktera")]
        public string Lozinka { get; set; }


        [Required(ErrorMessage = "Molimo potvrdite sifru"), DataType(DataType.Password),
            MaxLength(14), MinLength(3, ErrorMessage = "Sifra mora imati minimalno 3 karaktera")]
        [Remote(action: "ProvjeraPassworda", controller: "Registracija", areaName: "ModulKupac", AdditionalFields = "Lozinka")]

        public string PotvrdaLozinke { get; set; }


        [Required(ErrorMessage = "Molimo unesite ime"), DataType(DataType.Text), MaxLength(50),
            MinLength(3, ErrorMessage = "Polje ime mora imati minimalno 3 karaktera")]
        public string Ime { get; set; }


        [Required(ErrorMessage = "Molimo unesite prezime"), DataType(DataType.Text), MaxLength(100),
            MinLength(3, ErrorMessage = "Polje prezime mora sadrzavati najmanje 3 slova")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Molimo unesite email"), DataType(DataType.Text), MaxLength(200),
            MinLength(13, ErrorMessage = "Polje email mora sadrzavati minimalno 13 slova")]
        [Remote(action: "VerifyEmail", controller: "Registracija", areaName: "ModulKupac")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Molimo unesite adresu"), DataType(DataType.Text), MaxLength(200),
            MinLength(5, ErrorMessage = "Polje adresa mora sadrzavati minimalno 5 slova")]
        public string Adresa { get; set; }


        [Required(ErrorMessage = "Molimo odaberite spol")]
        //public int Id { get; set; }
        public string Spol { get; set; }

        [Required(ErrorMessage = "Obavezno je odabrati opštinu")]
        public int OpstinaID { get; set; }
        public List<Opstina> Opstine { get; set; }

    }
}
