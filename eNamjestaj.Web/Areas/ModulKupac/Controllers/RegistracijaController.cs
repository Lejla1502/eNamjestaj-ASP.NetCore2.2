using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulKupac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulKupac.Controllers
{
    [Autorizacija(false, true, false, true)]
    [Area("ModulKupac")]
    public class RegistracijaController : Controller
    {
        private MojContext ctx;

        public RegistracijaController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        [Autorizacija(false, true, false, true)]
        public IActionResult Index()
        {

            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
                Opstine = ctx.Opstina.ToList()
            };

            return View(model);
        }
        [Autorizacija(false, true, false, true)]
        public IActionResult Snimi(RegistracijaIndexVM model)
        {
            if (ModelState.IsValid)
            {
                byte[] lozinkaSalt = PasswordSettings.GetSalt();
                string lozinkaHash = PasswordSettings.GetHash(model.Lozinka, lozinkaSalt);

                Korisnik k = new Korisnik
                {
                    KorisnickoIme = model.KorisnickoIme,
                    LozinkaSalt= Convert.ToBase64String(lozinkaSalt),
                    LozinkaHash=lozinkaHash,
                    OpstinaId = model.OpstinaID,
                    UlogaId = 5
                };

                ctx.Korisnik.Add(k);
                ctx.SaveChanges();

                Kupac kupac = new Kupac
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Email = model.Email,
                    Adresa = model.Adresa,
                    Spol = model.Spol,
                    KorisnikId = k.Id
                };

                ctx.Kupac.Add(kupac);
                ctx.SaveChanges();

               
                return RedirectToAction("PrikazPoruke");
            }
            else
                return BadRequest(ModelState);


        }
        [Autorizacija(false, true, false, true)]
        public IActionResult PrikazPoruke()
        {

            return View();
        }


        public IActionResult ProvjeraPassworda(string PotvrdaLozinke, string Lozinka)
        {
            if (PotvrdaLozinke.Equals(Lozinka))
                return Json(true);
            return Json("Sifre se ne podudaraju");
        }


        public IActionResult VerifyUsername(string KorisnickoIme)
        {
            if (ctx.Korisnik.Any(x => x.KorisnickoIme == KorisnickoIme))
                return Json($"Korisnicko ime {KorisnickoIme} već postoji");
            return Json(true);
        }


        public IActionResult VerifyEmail(string Email)
        {
            if (ctx.Kupac.Any(x => x.Email == Email))
                return Json($"Unešeni email {Email} već postoji");
            return Json(true);
        }
    }
}