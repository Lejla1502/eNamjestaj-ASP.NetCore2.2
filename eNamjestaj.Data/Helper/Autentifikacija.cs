using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eNamjestaj.Data.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        
     

        public static Korisnik GetLogiraniKorisnik(this HttpContext context)
        {
            Korisnik korisnik = context.Session.Get<Korisnik>(LogiraniKorisnik);
            if (korisnik == null)
            {
                MojContext db = context.RequestServices.GetService<MojContext>();

                string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
                if (token == null)
                    return null;

               AutorizacijskiToken autorizacijskiToken= db.AutorizacijskiToken
                    .Include(x => x.Korisnik )
                    .SingleOrDefault(x=>x.Vrijednost==token);

                if (autorizacijskiToken != null)
                {
                    context.Session.Set(LogiraniKorisnik, autorizacijskiToken.Korisnik);
                }
            
            }
            return korisnik;
        }

       

        public static void SetLogiraniKorisnik(this HttpContext context, Korisnik korisnik,bool snimiUCookie=false)
        {
            
            context.Session.Set(LogiraniKorisnik,korisnik);

            if (snimiUCookie)
            {
                MojContext db = context.RequestServices.GetService<MojContext>();

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnikId = korisnik.Id,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);


            }
            else
                context.Response.SetCookieJson(LogiraniKorisnik, null );


        }



    }
}
