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
    [Autorizacija(false, true, false, false)]
    [Area("ModulKupac")]
    public class ProfilController : Controller
    {
        private MojContext ctx ;

        public ProfilController(MojContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();

            ProfilIndexVM model = new ProfilIndexVM
            {
                Ime = kupac.Ime,
                Prezime = kupac.Prezime,
                KorisnickoIme = k.KorisnickoIme,
                Email = kupac.Email,
                Adresa = kupac.Adresa,
                Opstina = ctx.Opstina.Where(o => o.Id == k.OpstinaId).FirstOrDefault().Naziv
            };

            return View(model);
        }

        public IActionResult VerifyUsername(string KorisnickoIme)
        {
            Korisnik ko = HttpContext.GetLogiraniKorisnik();
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


        public IActionResult VerifyEmail(string Email)
        {
            Korisnik ko = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == ko.Id).FirstOrDefault();
            List<Kupac> kupci = ctx.Kupac.ToList();
            foreach (Kupac k in kupci)
            {
                if (k.Id != kupac.Id)
                {
                    if (k.Email == Email)
                        return Json($"Korisnicko ime {Email} već postoji");
                }

            }
            return Json(true);
        }
    }

 }
    