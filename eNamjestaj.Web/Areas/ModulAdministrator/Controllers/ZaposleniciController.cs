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
    public class ZaposleniciController : Controller
    {
        private MojContext ctx;

        public ZaposleniciController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Uredi(int zaposlenikId)
        {
            Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == zaposlenikId).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == z.KorisnikId).First();
            ZaposleniciUrediVM model = new ZaposleniciUrediVM
            {
                ZaposlenikId = zaposlenikId,
                Ime = z.Ime,
                Prezime = z.Prezime,
                KorisnickoIme = k.KorisnickoIme,
                UlogaID = k.UlogaId,
                Uloge = ctx.Uloga.ToList()
            };

            return PartialView(model);
        }

        public IActionResult Snimi(ZaposleniciUrediVM model)
        {
            if (ModelState.IsValid)
            {
                Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == model.ZaposlenikId).First();
                Korisnik k = ctx.Korisnik.Where(x => x.Id == z.KorisnikId).First();
                k.KorisnickoIme = model.KorisnickoIme;

                k.UlogaId = model.UlogaID;
                ctx.SaveChanges();

                return RedirectToAction("IndexZaposlenici", "Korisnici");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int zaposlenikId)
        {

            Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == zaposlenikId).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == z.KorisnikId).First();

            ctx.Zaposlenik.Remove(z);
            ctx.SaveChanges();
            ctx.Korisnik.Remove(k);
            ctx.SaveChanges();

            return RedirectToAction("IndexZaposlenici", "Korisnici");
        }

        public IActionResult Dodaj()
        {
            ZaposleniciDodajVM model = new ZaposleniciDodajVM
            {
                Opstine = ctx.Opstina.ToList(),
                Uloge = ctx.Uloga.ToList()
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult SpremiNovogZaposlenika(ZaposleniciDodajVM model)
        {
            if (ModelState.IsValid)
            {
                Korisnik k = new Korisnik
                {
                    KorisnickoIme = model.KorisnickoIme,
                    Lozinka = model.Lozinka,
                    OpstinaId = model.OpstinaId,
                    UlogaId = model.UlogaId
                };
                ctx.Korisnik.Add(k);
                ctx.SaveChanges();

                Zaposlenik z = new Zaposlenik
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Email = model.Email,
                    Adresa = model.Adresa,
                    Telefon = model.Telefon,
                    KorisnikId = k.Id
                };
                ctx.Zaposlenik.Add(z);
                ctx.SaveChanges();

                return Redirect("/ModulAdministrator/Korisnici/IndexZaposlenici");
            }
            else
                return BadRequest(ModelState);
        }



        public IActionResult VerifyEmail(string Email)
        {
            List<Zaposlenik> zaposlenici = ctx.Zaposlenik.ToList();
            foreach (Zaposlenik z in zaposlenici)
            {
                if (z.Email == Email)
                    return Json($"Korisnicko ime {Email} već postoji");
            }
            return Json(true);
        }



        public IActionResult PostojiLiUsername(string KorisnickoIme)
        {
            List<Korisnik> korisnici = ctx.Korisnik.ToList();
            foreach (Korisnik k in korisnici)
            {

                if (k.KorisnickoIme == KorisnickoIme)
                    return Json($"Korisnicko ime {KorisnickoIme} već postoji");


            }
            return Json(true);
        }


        public IActionResult VerifyUsername(string KorisnickoIme, int ZaposlenikId)
        {
            Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == ZaposlenikId).First();

            Korisnik ko = ctx.Korisnik.Where(x => x.Id == z.KorisnikId).First();
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