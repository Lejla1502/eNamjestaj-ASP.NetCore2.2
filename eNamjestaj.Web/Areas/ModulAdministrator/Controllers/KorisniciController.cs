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
    [Area("ModulAdministrator")]
    public class KorisniciController : Controller
    {
        private MojContext ctx;
        public KorisniciController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            //Korisnik k = HttpContext.GetLogiraniKorisnik();

            return View();
        }

        public IActionResult IndexKupci()
        {
            KupciIndexVM model = new KupciIndexVM
            {
                Kupci = ctx.Kupac.Select(x => new KupciIndexVM.KorisnikInfo
                {
                    KupacId = x.Id,
                    KorisnickoIme = x.Korisnik.KorisnickoIme,
                    Ime = x.Ime,
                    Prezime = x.Prezime
                }).ToList()
            };

            return PartialView(model);
        }

        public IActionResult IndexZaposlenici()
        {
            ZaposleniciIndexVM model = new ZaposleniciIndexVM
            {
                Zaposlenici = ctx.Zaposlenik.Select(x => new ZaposleniciIndexVM.KorisnikInfo
                {
                    ZaposlenikId = x.Id,
                    KorisnickoIme = x.Korisnik.KorisnickoIme,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Uloga = x.Korisnik.Uloga.TipUloge
                }).ToList()
            };

            return PartialView(model);
        }

        public IActionResult NaslovnaStrana()
        {
            return View();
        }
    }
}