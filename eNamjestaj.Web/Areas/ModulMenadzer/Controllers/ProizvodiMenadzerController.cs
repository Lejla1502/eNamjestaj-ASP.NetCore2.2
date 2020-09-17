using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]

    public class ProizvodiMenadzerController : Controller
    {
       private  MojContext ctx ;

        private readonly IHostingEnvironment hostingEnvironment;
        public ProizvodiMenadzerController(IHostingEnvironment environment, MojContext context)
        {
            hostingEnvironment = environment;
            ctx = context;
        }
        public IActionResult Index(int? vrstaID)
        {
            ProizvodiIndexMenadzerVM model = new ProizvodiIndexMenadzerVM();
            model.Vrste = ctx.VrstaProizvoda.Select(y => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = y.Id.ToString(),
                Text = y.Naziv
            }).ToList();

            model.vrstaID = vrstaID;
            if (vrstaID == null)
            {
                model.Proizvodi = ctx.Proizvod.Select(x => new ProizvodiIndexMenadzerVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena.ToString("0.00"),
                    Sifra = x.Sifra,
                    Slika = x.Slika
                }).ToList();

            }
            else
            {
                model.Proizvodi = ctx.Proizvod.Where(x => x.VrstaProizvodaId == vrstaID).Select(x => new ProizvodiIndexMenadzerVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena.ToString("0.00"),
                    Sifra = x.Sifra,
                    Slika = x.Slika
                }).ToList();
            }
            return View("Index", model);

        }

        public IActionResult Dodaj()
        {
            Korisnik korisnik = HttpContext.GetLogiraniKorisnik();

            if (korisnik == null)
            {
                //TempData["error_poruka"] = "Nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija");
            }
            ProizvodiDodajVM model = new ProizvodiDodajVM
            {
                Vrste = ctx.VrstaProizvoda.ToList(),
                //Boje = ctx.Boja.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.Naziv
                //}).ToList(),
                Boje = new SelectList(ctx.Boja.ToList(), "Id", "Naziv")
            };

            return View(model);
        }

        

        [HttpPost]
        public IActionResult UploadProduct(ProizvodiDodajVM p)
        {
            if (ModelState.IsValid)
            {
                Proizvod x = new Proizvod();


                //FileUpload fu = new FileUpload();
                //fu = p.FileUpl;
                IFormFile uploadedImage = p.UploadPic;
                if (uploadedImage == null || p.UploadPic.Length == 0)
                    return RedirectToAction("Dodaj");


                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);

               System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                //string pathDir = "C:/Users/Lejla/Desktop/Slike namjestaj/";

                //var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //var fullPath = Path.Combine(uploads, p.UploadPic.FileName);

                var webRoot = hostingEnvironment.WebRootPath;
                string location = "/images/Namjestaj/";

                if (!System.IO.Directory.Exists(webRoot + location))
                {
                    System.IO.Directory.CreateDirectory(webRoot + location);
                }

                var path = Path.Combine(
                          Directory.GetCurrentDirectory(), "wwwroot" + location,
                          p.UploadPic.FileName);
                p.UploadPic.CopyTo(new FileStream(path, FileMode.Create));

                //x.Cijena = decimal.Parse(p.Cijena.Replace('.', ','));
                x.Cijena = decimal.Parse(p.Cijena);
                x.Naziv = p.Naziv;
                x.Sifra = p.Sifra;

                x.KorisnikId = HttpContext.GetLogiraniKorisnik().Id;
                x.VrstaProizvodaId = p.VrstaID;
                x.Slika = location + uploadedImage.FileName;

                ctx.Proizvod.Add(x);

                ctx.SaveChanges();




                foreach (int b in p.BojeID)
                {
                    ProizvodBoja pb = new ProizvodBoja()
                    {
                        ProizvodId = x.Id,
                        BojaId = b
                    };

                    ctx.ProizvodBoja.Add(pb);
                }
                ctx.SaveChanges();


                return RedirectToAction("Index", "ProizvodiMenadzer");
            }
            else
            {

                return BadRequest(ModelState);
            }
        }



        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifySifra(string Sifra, int ProizvodId)
        {
            if (ProizvodId == 0)
            {
                List<Proizvod> proizvodi = ctx.Proizvod.ToList();
                foreach (Proizvod p in proizvodi)
                {
                    if (p.Sifra.Equals(Sifra))
                        return Json($"Sifra {Sifra} vec postoji.");
                }

            }
            return Json(true);


        }

        public IActionResult Uredi(int id)
        {
            Proizvod p = ctx.Proizvod.Find(id);

            ProizvodiUrediVM model = new ProizvodiUrediVM
            {
                ProizvodId = id,
                Naziv = p.Naziv,
                Sifra = p.Sifra,
                Cijena = p.Cijena.ToString("0.00").Replace(",", "."),
                VrstaID = p.VrstaProizvodaId,
                Vrste = ctx.VrstaProizvoda.ToList(),
                //Boje = ctx.Boja.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem {
                //    Value = b.Id.ToString(), Text = b.Naziv
                //}).ToList(),
                BojeID = ctx.ProizvodBoja.Where(pb => pb.ProizvodId == id).Select(x => x.BojaId).ToArray(),
                //Boje =new SelectList(ctx.Boja.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                //{
                //       Value = b.Id.ToString(), Text = b.Naziv
                //    }).ToList() ),
                Boje = new SelectList(ctx.Boja.ToList(), "Id", "Naziv"),
                Slika = p.Slika

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProductSave(ProizvodiUrediVM p)
        {
            if (ModelState.IsValid)
            {
                Proizvod x = ctx.Proizvod.Find(p.ProizvodId);
                foreach (ProizvodBoja y in ctx.ProizvodBoja.Where(z => z.ProizvodId == p.ProizvodId).ToList())
                {
                    ctx.ProizvodBoja.Remove(y);
                    ctx.SaveChanges();
                }


                IFormFile uploadedImage = p.UploadPic;
                if (uploadedImage == null || p.UploadPic.Length == 0)
                {
                    x.Slika = p.Slika;
                }

                else
                {
                    MemoryStream ms = new MemoryStream();
                    uploadedImage.OpenReadStream().CopyTo(ms);

                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                    var webRoot = hostingEnvironment.WebRootPath;
                    string location = "/images/Namjestaj/";

                    if (!System.IO.Directory.Exists(webRoot + location))
                    {
                        System.IO.Directory.CreateDirectory(webRoot + location);
                    }

                    var path = Path.Combine(
                              Directory.GetCurrentDirectory(), "wwwroot" + location,
                              p.UploadPic.FileName);
                    p.UploadPic.CopyTo(new FileStream(path, FileMode.Create));
                    x.Slika = location + uploadedImage.FileName;
                }

                x.Cijena = decimal.Parse(p.Cijena);
                x.Naziv = p.Naziv;
                x.Sifra = p.Sifra;
                x.KorisnikId = HttpContext.GetLogiraniKorisnik().Id;
                x.VrstaProizvodaId = p.VrstaID;


                ctx.SaveChanges();


                foreach (int b in p.BojeID)
                {
                    ProizvodBoja pb = new ProizvodBoja()
                    {

                        ProizvodId = x.Id,
                        BojaId = b
                    };

                    ctx.ProizvodBoja.Add(pb);
                }

                ctx.SaveChanges();


                return RedirectToAction("Index", "ProizvodiMenadzer");
            }
            else
                return BadRequest(ModelState);
        }

        //public IActionResult Obrisi(int id)
        //{
        //    Proizvod p = ctx.Proizvod.Find(id);

        //    foreach (ProizvodBoja x in ctx.ProizvodBoja.Where(x => x.ProizvodId == id).ToList())
        //    {
        //        ctx.ProizvodBoja.Remove(x);
        //        ctx.SaveChanges();
        //    }

        //    ctx.Proizvod.Remove(p);
        //    ctx.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        public IActionResult Obrisi(int id)
        {
            Proizvod p = ctx.Proizvod.Find(id);

            foreach (ProizvodBoja x in ctx.ProizvodBoja.Where(x => x.ProizvodId == id).ToList())
            {
                ctx.ProizvodBoja.Remove(x);
                ctx.SaveChanges();
            }

            ctx.Proizvod.Remove(p);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}