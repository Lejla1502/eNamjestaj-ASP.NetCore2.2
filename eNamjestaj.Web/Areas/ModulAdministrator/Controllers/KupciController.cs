using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulAdministrator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true, false, false, false)]
    //[Audit]
    [Area("ModulAdministrator")]
    public class KupciController : Controller
    {
        private MojContext ctx ;

        public KupciController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Uredi(int kupacId)
        {
            Kupac kupac = ctx.Kupac.Where(x => x.Id == kupacId).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == kupac.KorisnikId).First();
            KupciUrediVM model = new KupciUrediVM
            {
                KupacId = kupacId,
                Ime = kupac.Ime,
                Prezime = kupac.Prezime,
                KorisnickoIme = k.KorisnickoIme,
                Lozinka = k.Lozinka,
                PotvrdaLozinke = k.Lozinka
            };

            return PartialView(model);
        }

        public IActionResult Obrisi(int kupacId)
        {

            Kupac kupac = ctx.Kupac.Where(x => x.Id == kupacId).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == kupac.KorisnikId).First();

            ctx.Kupac.Remove(kupac);
            ctx.SaveChanges();
            ctx.Korisnik.Remove(k);
            ctx.SaveChanges();

            return RedirectToAction("IndexKupci", "Korisnici");
        }

        public IActionResult Snimi(KupciUrediVM model)
        {
            if (ModelState.IsValid)
            {
                Kupac kupac = ctx.Kupac.Where(x => x.Id == model.KupacId).First();
                Korisnik k = ctx.Korisnik.Where(x => x.Id == kupac.KorisnikId).First();
                k.KorisnickoIme = model.KorisnickoIme;
                k.Lozinka = model.Lozinka;
                ctx.SaveChanges();

                return RedirectToAction("IndexKupci", "Korisnici");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult VerifyUsername(string KorisnickoIme, int KupacId)
        {
            Kupac kupac = ctx.Kupac.Where(x => x.Id == KupacId).First();

            Korisnik ko = ctx.Korisnik.Where(x => x.Id == kupac.KorisnikId).First();
            List<Korisnik> korisnici = ctx.Korisnik.ToList();
            foreach (Korisnik k in korisnici)
            {
                if (k.Id != ko.Id)
                {
                    if (k.KorisnickoIme == KorisnickoIme)
                        return Json($"Korisnicko ime {KorisnickoIme} već postoji");
                }

            }
            return Json(true);
        }

        public IActionResult ProvjeraPassworda(string PotvrdaLozinke, string Lozinka)
        {
            if (PotvrdaLozinke.Equals(Lozinka))
                return Json(true);
            return Json("Sifre se ne podudaraju");
        }
    }
}