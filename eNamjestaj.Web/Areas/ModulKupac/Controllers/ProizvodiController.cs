using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulKupac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNamjestaj.Web.Areas.ModulKupac.Controllers
{
    [Audit]
    [Area("ModulKupac")]

    public class ProizvodiController : Controller
    {
        

        private MojContext ctx;
        

        public ProizvodiController(MojContext context)
        {
            ctx=context;
        }

        int broj = 1;

        [Autorizacija(false, true, false, true)]
        public IActionResult Index(int? vrstaID, int? bojaID)
        {
            ProizvodiIndexVM model = new ProizvodiIndexVM();

            model.Vrste = ctx.VrstaProizvoda.Select(y => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = y.Id.ToString(),
                Text = y.Naziv
            }).ToList();

            model.Boje = ctx.Boja.Select(y => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = y.Id.ToString(),
                Text = y.Naziv
            }).ToList();

            int katalogAkt = ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).Count();
            int katalogID = 0;
            if (katalogAkt > 0)
                katalogID = ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).FirstOrDefault().Id;



            if (vrstaID == null && bojaID == null)
            {
                model.Proizvodi = ctx.Proizvod.Select(x => new ProizvodiIndexVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Sifra = x.Sifra,
                    Slika = x.Slika,
                    Popust = (katalogID == 0) ? 0 :( (ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).Count()==1)? (ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).FirstOrDefault().PopustProcent):0),
                    BrojacBoja = ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count(),
                    Boja = (ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count() == 1) ? (ctx.ProizvodBoja.Where(pb => pb.ProizvodId == x.Id)).First().Boja.Naziv : ((ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count() == 0) ? "Boja nije određena" : "**Više boja"),
                    KonacnaCijena = x.Cijena - (x.Cijena * ((ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).Count() == 1) ? (ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).FirstOrDefault().PopustProcent) : 0) / 100)
                }).ToList();
            }
            else
            {
                model.Proizvodi = ctx.Proizvod.Where(x => x.VrstaProizvodaId == vrstaID && bojaID == null ||
                                     ((x.ProizvodBojas.Any(pb => pb.BojaId == bojaID) && vrstaID == null) ||
                                     (x.VrstaProizvodaId == vrstaID && x.ProizvodBojas.Any(pb => pb.BojaId == bojaID)))
                                    ).Select(x => new ProizvodiIndexVM.ProizvodiInfo
                                    {
                                        Id = x.Id,
                                        Naziv = x.Naziv,
                                        Cijena = x.Cijena,
                                        Sifra = x.Sifra,
                                        Slika = x.Slika,
                                        BrojacBoja = ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count(),
                                        Boja = (ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count() == 1) ? (ctx.ProizvodBoja.Where(pb => pb.ProizvodId == x.Id)).First().Boja.Naziv : ((ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count() == 0) ? "Boja nije određena" : "**Više boja"),
                                        //Popust = (katalogID == 0) ? 0 : ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).FirstOrDefault().PopustProcent,
                                        Popust = (katalogID == 0) ? 0 : ((ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).Count() == 1) ? (ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).FirstOrDefault().PopustProcent) : 0),
                                        KonacnaCijena = x.Cijena - (x.Cijena * ((ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).Count() == 1) ? (ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).FirstOrDefault().PopustProcent) : 0) / 100)
                                        // KonacnaCijena = x.Cijena - (x.Cijena * ctx.KatalogStavka.Where(s => s.AkcijskiKatalogId == katalogID && s.ProizvodId == x.Id).FirstOrDefault().PopustProcent / 100)
                                    }).ToList();
            }

            
            
            return View(model);
        }

        [Autorizacija(false, true, false, true)]
        public IActionResult Detalji(int proizvodId, int brojac,int? popust)
        {
            ProizvodiDetaljiVM model = ctx.Proizvod.Where(x => x.Id == proizvodId).Select(y => new ProizvodiDetaljiVM
            {
                ProizvodId = y.Id,
                Naziv = y.Naziv,
                Slika = y.Slika,
                Cijena = y.Cijena,
                Sifra = y.Sifra,
                Vrsta = y.VrstaProizvoda.Naziv,
                Brojac = brojac,
                Popust = popust,
                KonacnaCijena = y.Cijena - (y.Cijena * ((popust==null)?0:popust) / 100)
            }).FirstOrDefault();



            if (brojac > 1)
                model.Boje = ctx.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = b.BojaId.ToString(),
                    Text = b.Boja.Naziv
                }).ToList();
            else
            {
                model.BojaID = ctx.ProizvodBoja.Where(m => m.ProizvodId == proizvodId).Include(m => m.Boja).First().Boja.Id;
                model.Boja = ctx.ProizvodBoja.Where(m => m.ProizvodId == proizvodId).Include(m => m.Boja).First().Boja.Naziv;
            }
            return View(model);
        }

        [Autorizacija(false, true, false, false)]
        public IActionResult ProvjeraKolicine(int ProizvodId, int kol, int BojaID, int Brojac, int? Popust)
        {
            if (ModelState.IsValid)
            {
                if (Popust == null)
                    Popust = 0;
                Proizvod p = ctx.Proizvod.Find(ProizvodId);
            ProizvodSkladiste ps = ctx.ProizvodSkladiste.Where(x => x.ProizvodId == p.Id).First();

                
                Korisnik k = HttpContext.GetLogiraniKorisnik();
                Kupac kupacLogiran = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();

                if (kupacLogiran == null)
                return RedirectToAction("Index", "Login");



            Narudzba aktivna = null;
            int aktivnaBr = ctx.Narudzba.Where(x => x.KupacId == kupacLogiran.Id && x.Aktivna == true).Count();
            if (aktivnaBr > 0)
                aktivna = ctx.Narudzba.Where(x => x.KupacId == kupacLogiran.Id && x.Aktivna == true).First();

            
                if (ps.Kolicina >= kol)
                {
                    if (aktivna == null)
                    {
                        //int brojNarudzbe = 1;
                        if (ctx.Narudzba.Count() > 0)
                        {
                            broj = Convert.ToInt32(ctx.Narudzba.Last().BrojNarudzbe) + 1;
                        }
                       
                        Narudzba n = new Narudzba
                        {
                            BrojNarudzbe = broj.ToString(),
                            Datum = DateTime.Now,
                            Status = true,
                            Otkazano = false,
                            Aktivna = true,
                            NaCekanju=false,
                            KupacId = kupacLogiran.Id
                        };
                        ctx.Narudzba.Add(n);
                        ctx.SaveChanges();

                       // TempData["error_poruka"] = "Proizvod uspješno dodat!";

                        NarudzbaStavka ns = new NarudzbaStavka
                        {
                            Kolicina = kol,
                            ProizvodId = ProizvodId,
                            NarudzbaId = n.Id,
                            BojaId = BojaID,
                            CijenaProizvoda = p.Cijena,
                            PopustNaCijenu = Popust ?? 0,
                            //TotalStavke=p.Cijena*kol
                            TotalStavke = (p.Cijena - (p.Cijena * (decimal)Popust / 100)) * kol
                        };
                        ctx.NarudzbaStavka.Add(ns);
                        //broj++;
                        ps.Kolicina -= kol;


                        // HttpContext.SetAKtivnaNarudzba(n);
                    }
                    else
                    {
                        Narudzba n1 = ctx.Narudzba.Where(n => n.KupacId == kupacLogiran.Id && n.Id == aktivna.Id).First();
                        bool postoji = false;

                        foreach (var x in ctx.NarudzbaStavka.Where(x => x.NarudzbaId == n1.Id).ToList())
                        {
                            if (x.ProizvodId == ProizvodId && x.BojaId == BojaID)
                            {
                                NarudzbaStavka nsUpdate = ctx.NarudzbaStavka.Where(y => y.Id == x.Id).First();
                                nsUpdate.Kolicina += kol;
                                ctx.SaveChanges();
                                ps.Kolicina -= kol;
                                nsUpdate.TotalStavke = (p.Cijena - (p.Cijena * (decimal)Popust / 100)) * nsUpdate.Kolicina;
                                postoji = true;
                            }
                        }

                        if (!postoji)
                        {
                            ctx.NarudzbaStavka.Add(new NarudzbaStavka
                            {
                                Kolicina = kol,
                                ProizvodId = ProizvodId,
                                NarudzbaId = n1.Id,
                                BojaId = BojaID,
                                CijenaProizvoda = p.Cijena,
                                PopustNaCijenu = Popust ?? 0,
                                TotalStavke = (p.Cijena - (p.Cijena * (decimal)Popust / 100)) * kol
                            });
                            ps.Kolicina -= kol;
                        }

                    }
                    ctx.SaveChanges();
                    return RedirectToAction("Index", "NarudzbaStavke");
                }
                //return RedirectToAction("Index", "NarudzbaStavke");
                return RedirectToAction("Detalji", new { @proizvodId = ProizvodId, @brojac = Brojac });

            }
            else
            {
                //TempData["error_poruka"] = "Prozvoda nema na stanju u datoj količini!";
                return RedirectToAction("Detalji", new { @proizvodId = ProizvodId, @brojac = Brojac });
            }
        }




    }
}