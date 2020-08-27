using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNamjestaj.Web.Controllers
{
    public class NarudzbeController : Controller
    {
        private MojContext ctx;
        public NarudzbeController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            List<Narudzba> n = new List<Narudzba>();
            Korisnik ko = HttpContext.GetLogiraniKorisnik();
            Kupac k = ctx.Kupac.Where(x => x.KorisnikId == ko.Id).FirstOrDefault();

            int brNarudzbi = ctx.Narudzba.Where(x => x.KupacId == k.Id && x.NaCekanju == false && x.Aktivna==false).Count();
            // n=  ctx.Narudzba.Where(y => y.KupacId == HttpContext.GetLogiraniKorisnik().KupacId && y.Status == false).ToList();
            if (brNarudzbi > 0)
            {
                NarudzbeIndexVM model = new NarudzbeIndexVM
                {
                    Narudzbe = ctx.Narudzba.Where(y => y.KupacId == k.Id && y.NaCekanju == false && y.Aktivna==false).Select(x => new NarudzbeIndexVM.NarudzbeInfo
                    {
                        NarudzbaId = x.Id,
                        Datum = x.Datum,
                        UkupanIznos = ctx.Izlaz.Where(i => i.NarudzbaId == x.Id).FirstOrDefault().IznosSaPDV.ToString(),
                        Status = x.Status,
                        Otkazana = x.Otkazano,
                        Kompletirana = ctx.Izlaz.Where(i => i.NarudzbaId == x.Id).FirstOrDefault().Zakljucena
                    }).ToList()
                };

                return View(model);
            }

            else
                return View(null);
        }
    

        public IActionResult Zakljuci(int narudzbaID, int dostava, string total)
        {
            if (ModelState.IsValid)
            {
                //KupacLoginVM k = null;// HttpContext.GetLogiraniKorisnik();
                //AktivnaNarudzba n = null;// HttpContext.GetAktivnaNarudzba();
                Narudzba n = ctx.Narudzba.Where(x => x.Id == narudzbaID).FirstOrDefault();
                n.NaCekanju = true;
                n.Aktivna = false;
                //ctx.Narudzba.Where(na => na.Id == n.Id).First().Status = false;
                ctx.SaveChanges();

                decimal totalDec = Convert.ToDecimal(total);

                Izlaz i = new Izlaz
                {
                    NarudzbaId = narudzbaID,
                    BrojNarudzbe = n.BrojNarudzbe,
                    Datum = DateTime.Now,
                    Zakljucena = false,
                    IznosSaPDV = totalDec,
                    IznosBezPDV = totalDec - (totalDec / 17),
                    DostavaId = Convert.ToInt32(dostava),
                    SkladisteId = 1
                };
                ctx.Izlaz.Add(i);
                ctx.SaveChanges();

                foreach (var x in ctx.NarudzbaStavka.Where(x => x.NarudzbaId == narudzbaID).Include(q => q.Proizvod).ToList())
                {
                    IzlazStavka ns = new IzlazStavka
                    {
                        Cijena = x.CijenaProizvoda,
                        Popust = x.PopustNaCijenu,
                        Konacnacijena = x.TotalStavke,
                        Kolicina = x.Kolicina,
                        ProizvodId = x.ProizvodId,
                        IzlazId = i.IzlazId
                    };
                    ctx.IzlaziStavka.Add(ns);
                }

                ctx.SaveChanges();
                return PartialView("Zakljuci");
            }
            else
                return RedirectToAction("Index", "NarudzbaStavke");
        }

        public IActionResult Detalji(int narudzbaId)
        {
            List<NarudzbaStavka> ns = new List<NarudzbaStavka>();
            ns = ctx.NarudzbaStavka.Where(y => y.NarudzbaId == narudzbaId).ToList();

            NarudzbeDetaljiVM model = new NarudzbeDetaljiVM
            {
                DetaljiNarudzbe = ctx.NarudzbaStavka.Where(y => y.NarudzbaId == narudzbaId).Select(x => new NarudzbeDetaljiVM.NarudzbeStavkeInfo
                {
                    Proizvod = x.Proizvod.Naziv,
                    Cijena = x.Proizvod.Cijena.ToString("0.00"),
                    Kolicina = x.Kolicina,
                    Boja = x.Boja.Naziv,
                    Dostava = ctx.Izlaz.Where(i => i.NarudzbaId == narudzbaId).FirstOrDefault().Dostava.Cijena.ToString("0.00"),
                    Total = x.TotalStavke.ToString("0.00")
                }).ToList(),
                SumTotal = ctx.Izlaz.Where(i => i.NarudzbaId == narudzbaId).FirstOrDefault().IznosSaPDV.ToString("0.00"),
                NarudzbaID = narudzbaId
            };

            return PartialView(model);
        }

    }
}