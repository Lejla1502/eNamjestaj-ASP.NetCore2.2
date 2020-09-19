using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleAuthenticatorService.Core;
using eNamjestaj.Web.Areas.ModulKupac.ViewModels;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data;
using eNamjestaj.Data.Models;

namespace eNamjestaj.Web.Areas.ModulKupac.Controllers
{
    [Area("ModulKupac")]
    [Autorizacija(false, true, false, false)]
 
    public class TwoFactorAuthenticationController : Controller
    {
        private MojContext ctx;
        public TwoFactorAuthenticationController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null)
            {
                 return Redirect("/Autentifikacija/Index");
            }
            var hasAuthenticator = (String.IsNullOrEmpty(k.TwoFactorUniqueKey))?false:true;
            ViewData["HasAuthenticator"] = hasAuthenticator;

            return View();
        }

        
        public ActionResult DozvoliAutentifikator()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null)
            {
                return Redirect("/Autentifikacija/Index");
            }

            TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                var userUniqueKey = Guid.NewGuid().ToString().Replace("-", "");
                var setupInfo = TwoFacAuth.GenerateSetupCode("Online namjestaj",k.KorisnickoIme , userUniqueKey, 300, 300);

                var model = new KupacAutentifikatorVM();
                model.TwoFactorUserUniqueKey = userUniqueKey;
                model.TwoFactorBarcodeImage = setupInfo.QrCodeSetupImageUrl;
                model.TwoFactorCode = setupInfo.ManualEntryKey;

               return View(model);
           
        }

      
        [HttpPost]
        public ActionResult SnimiAutentifikator(KupacAutentifikatorVM model)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if(k==null)
            {
                 return Redirect("/Autentifikacija/Index");
            }

                TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                bool isValid = TwoFacAuth.ValidateTwoFactorPIN(model.TwoFactorUserUniqueKey, model.TwoFactorPin);

            if (isValid)
            {
                k.TwoFactorUniqueKey = model.TwoFactorUserUniqueKey;
                ctx.SaveChanges();

                bool token = false;
                if (ctx.AutorizacijskiToken.Where(a => a.KorisnikId == k.Id).Count() > 0)
                    token = true;
                HttpContext.SetLogiraniKorisnik(k,token);
                
            }
           

            return RedirectToAction("Index");
        }

        public ActionResult BrisiAutentifikator()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null)
            {
                return Redirect("/Autentifikacija/Index");
            }

            if (!String.IsNullOrEmpty(k.TwoFactorUniqueKey))
            {
                k.TwoFactorUniqueKey = null;
                ctx.SaveChanges();

                bool token = false;
                if (ctx.AutorizacijskiToken.Where(a => a.KorisnikId == k.Id).Count() > 0)
                    token = true;
                HttpContext.SetLogiraniKorisnik(k, token);

            }

           

            return RedirectToAction("Index");
        }

        

    }
}