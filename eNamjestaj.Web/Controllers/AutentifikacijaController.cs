using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        //MojContext ctx = new MojContext();

        private MojContext ctx;

        public AutentifikacijaController(MojContext context)
        {
            ctx = context;
        }

        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true,
            });
        }
        public IActionResult Login(LoginVM input)
        {
            if (!ModelState.IsValid)
            {
                ViewData["poruka"] = "Niste unijeli ispravne podatke";
                return View("Index", input);
            }
            Korisnik korisnik = ctx.Korisnik
                .SingleOrDefault(x => x.KorisnickoIme == input.username && x.Lozinka == input.password);

            if (korisnik == null)
            {
                ViewData["poruka"] = "Pogrešan username ili password";
                return View("Index", input);
            }
int t=0;
            HttpContext.SetLogiraniKorisnik(korisnik, snimiUCookie: input.ZapamtiPassword);
          
            return RedirectToAction("Index", "Proizvodi");
        }

        public IActionResult Logout()
        {
            HttpContext.SetLogiraniKorisnik(null);

            return RedirectToAction("Index","Proizvodi");
        }
    }
}