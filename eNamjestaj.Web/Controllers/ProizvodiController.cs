using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNamjestaj.Web.Controllers
{
    public class ProizvodiController : Controller
    {
        MojContext ctx = new MojContext();

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


            if (vrstaID == null && bojaID == null)
            {
                model.Proizvodi = ctx.Proizvod.Select(x => new ProizvodiIndexVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Sifra = x.Sifra,
                    Slika = x.Slika,
                    KonacnaCijena = x.Cijena,
                    BrojacBoja = ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count(),
                    Boja = (ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count() == 1) ? (ctx.ProizvodBoja.Where(pb => pb.ProizvodId == x.Id)).First().Boja.Naziv : ((ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count() == 0) ? "Boja nije određena" : "**Više boja"),
                    // KonacnaCijena = x.Cijena - (x.Cijena * ctx.KatalogStavka.Where(s => s.AkcijskiKatalogId == 1 && s.ProizvodId == x.Id).FirstOrDefault().PopustProcent / 100)
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
                                        //Popust = (katalogID == null) ? 0 : ctx.KatalogStavka.Where(s => s.ProizvodId == x.Id && s.AkcijskiKatalogId == katalogID).FirstOrDefault().PopustProcent,
                                        //KonacnaCijena = x.Cijena - (x.Cijena * ctx.KatalogStavka.Where(s => s.AkcijskiKatalogId == 1 && s.ProizvodId == x.Id).FirstOrDefault().PopustProcent / 100)
                                    }).ToList();
            }

            
            
            return View(model);
        }

        public IActionResult Detalji(int proizvodId, int brojac)
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
                //Popust = ctx.KatalogStavka.Where(s => s.AkcijskiKatalogId == 1 && s.ProizvodId == y.Id).FirstOrDefault().PopustProcent,
                //KonacnaCijena = y.Cijena - (y.Cijena * ctx.KatalogStavka.Where(s => s.AkcijskiKatalogId == 1 && s.ProizvodId == y.Id).FirstOrDefault().PopustProcent / 100)
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


    }
}