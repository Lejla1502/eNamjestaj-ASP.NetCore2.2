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
    }
}