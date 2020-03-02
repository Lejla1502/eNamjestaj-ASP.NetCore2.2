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
        MojContext ctx = new MojContext();


        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true,
            });
        }
        public IActionResult Login(LoginVM input)
        {
            Korisnik korisnik = ctx.Korisnik
                .SingleOrDefault(x => x.KorisnickoIme == input.username && x.Lozinka == input.password);

            if (korisnik == null)
            {
                ViewData["poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SetLogiraniKorisnik(null);

            return RedirectToAction("Index");
        }
    }
}