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
            MojContext db = context.RequestServices.GetService<MojContext>();

           string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;
                 
            return db.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.Korisnik)
                .SingleOrDefault();
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static void SetLogiraniKorisnik(this HttpContext context, Korisnik korisnik,bool snimiUCookie=false)
        {
            MojContext db = context.RequestServices.GetService<MojContext>();


            string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {

                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);

                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            if (korisnik != null)
            {

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


        }



    }
}
