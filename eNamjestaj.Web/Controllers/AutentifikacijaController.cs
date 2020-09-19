using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.ViewModels;
using GoogleAuthenticatorService.Core;
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

            if (!String.IsNullOrEmpty(korisnik.TwoFactorUniqueKey))
            {
                var twoFactorModel = new LoginTwoFactorVM
                {
                    username = korisnik.KorisnickoIme,
                    password = korisnik.Lozinka,
                    ZapamtiLozinku = input.ZapamtiPassword
                };

                return View("LoginTwoFactor", twoFactorModel);
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(korisnik, snimiUCookie: input.ZapamtiPassword);
                return RedirectToAction("Index", "Home");
            }
          
           
        }

        [HttpPost]
        public IActionResult LoginTwoFactor(LoginTwoFactorVM model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login" );
            }

            Korisnik korisnik = ctx.Korisnik
                .SingleOrDefault(x => x.KorisnickoIme == model.username && x.Lozinka == model.password);

            if (korisnik == null)
            {
                ViewData["poruka"] = "Pogrešan username ili password";
                return View("Login");
            }


            TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
            string current = TwoFacAuth.GetCurrentPIN(korisnik.TwoFactorUniqueKey);
            bool isValid = current.Equals(model.TwoFactorPin);
            //bool isValid = true;
            if (isValid)
            {
                HttpContext.SetLogiraniKorisnik(korisnik, snimiUCookie: model.ZapamtiLozinku);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["poruka"] = "Pogrešan kod";
                return View("LoginTwoFactor",model);
            }
            

            
        }

        public IActionResult Logout()
        {
            HttpContext.SetLogiraniKorisnik(null);

            return RedirectToAction("Index");
        }
    }
}