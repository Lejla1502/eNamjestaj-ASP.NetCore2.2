using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Controllers
{
    public class ProizvodiController : Controller
    {
        MojContext ctx = new MojContext();

        public IActionResult Index()
        {
            ProizvodiIndexVM model = new ProizvodiIndexVM();
           
   
             model.Proizvodi = ctx.Proizvod.Select(x => new ProizvodiIndexVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Sifra = x.Sifra,
                    Slika = x.Slika,
                    KonacnaCijena=x.Cijena
                   // KonacnaCijena = x.Cijena - (x.Cijena * ctx.KatalogStavka.Where(s => s.AkcijskiKatalogId == 1 && s.ProizvodId == x.Id).FirstOrDefault().PopustProcent / 100)
                }).ToList();

            
            
            return View(model);
        }

    }
}