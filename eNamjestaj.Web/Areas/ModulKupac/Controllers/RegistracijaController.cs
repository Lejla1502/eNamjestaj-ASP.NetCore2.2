using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
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

        public IActionResult Index()
        {

            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
                Opstine = ctx.Opstina.ToList()
            };

            return View(model);
        }

        public IActionResult Snimi(RegistracijaIndexVM model)
        {
            return RedirectToAction("Index");
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