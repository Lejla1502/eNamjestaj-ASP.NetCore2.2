using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Web.Areas.ModulKupac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulKupac.Controllers
{
    [Autorizacija(false, true, false, true)]
    [Audit]
    [Audit]
    [Area("ModulKupac")]
    public class AkcijskiKatalogKupacController : Controller
    {
        private MojContext ctx;

        public AkcijskiKatalogKupacController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        
        public IActionResult Index()
        {


            int katalogAkt = ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).Count();
            int? katalogID = null;
            if (katalogAkt > 0)
            {

                katalogID = ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).FirstOrDefault().Id;

                AkcijskiKatalogKupacIndexVM model = new AkcijskiKatalogKupacIndexVM()
                {
                    NazivKataloga = ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).FirstOrDefault().Opis,
                    Proizvodi = ctx.KatalogStavka.Where(ks=>ks.AkcijskiKatalogId==katalogID).Select(x => new AkcijskiKatalogKupacIndexVM.ProizvodiKatalogInfo
                    {
                        Id = x.Proizvod.Id,
                        Naziv = x.Proizvod.Naziv,
                        Cijena = x.Proizvod.Cijena,
                        Sifra = x.Proizvod.Sifra,
                        Slika = x.Proizvod.Slika,
                        BrojacBoja = ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Id).Count(),
                        Boja = (ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Proizvod.Id).Count() == 1) ? (ctx.ProizvodBoja.Where(pb => pb.ProizvodId == x.Proizvod.Id)).First().Boja.Naziv : ((ctx.ProizvodBoja.Where(p => p.ProizvodId == x.Proizvod.Id).Count() == 0) ? "Boja nije određena" : "**Više boja"),
                        Popust = x.PopustProcent,
                        KonacnaCijena = x.Proizvod.Cijena - (x.Proizvod.Cijena * x.PopustProcent / 100),
                        Vrsta = ctx.VrstaProizvoda.Where(v => v.Id == x.Proizvod.VrstaProizvodaId).FirstOrDefault().Naziv
                    }).ToList()
                };
                return View(model);
            }
            else
                return View(null);

        }

    }
}
